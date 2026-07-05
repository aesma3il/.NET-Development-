using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem
{
    // ========== DOMAIN MODELS ==========

    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class Customer : Entity
    {
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal CurrentBalance { get; private set; }
        public bool IsActive { get; private set; }

        public Customer()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            CurrentBalance = 0;
        }

        // Constructor for seeding data
        public Customer(string customerName, string phoneNumber, decimal initialBalance) : this()
        {
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            CurrentBalance = initialBalance;
        }

        public void UpdateBalance(decimal newBalance)
        {
            if (newBalance < 0)
                throw new BusinessException("Current balance cannot be negative.");
            CurrentBalance = newBalance;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            if (IsActive)
                throw new BusinessException("Customer is already active.");
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            if (!IsActive)
                throw new BusinessException("Customer is already inactive.");
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateInfo(string customerName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ValidationException("Customer name is required.");
            if (customerName.Length < 2 || customerName.Length > 100)
                throw new ValidationException("Customer name must be between 2 and 100 characters.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ValidationException("Phone number is required.");

            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            UpdatedAt = DateTime.UtcNow;
        }
    }

    // ========== VALUE OBJECTS ==========

    public class PaginationInfo
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int FirstItemIndex => (CurrentPage - 1) * PageSize + 1;
        public int LastItemIndex => Math.Min(CurrentPage * PageSize, TotalItems);
    }

    public class PageResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PaginationInfo Pagination { get; set; }

        public PageResult()
        {
            Items = new List<T>();
            Pagination = new PaginationInfo();
        }
    }

    public class SearchCriteria
    {
        public string SearchTerm { get; set; }
        public SearchMode SearchMode { get; set; }
        public CustomerFilter Filter { get; set; }
        public AdvancedSearchOptions AdvancedOptions { get; set; }

        public SearchCriteria()
        {
            SearchMode = SearchMode.Contains;
        }
    }

    public enum SearchMode
    {
        Contains,
        StartsWith,
        ExactMatch
    }

    public class CustomerFilter
    {
        public bool? IsActive { get; set; }
        public decimal? MinBalance { get; set; }
        public decimal? MaxBalance { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
    }

    public class AdvancedSearchOptions
    {
        public string CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }

    // ========== EXCEPTIONS ==========

    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public class SystemException : Exception
    {
        public SystemException(string message) : base(message) { }
    }

    // ========== DELEGATES AND EVENTS ==========

    public delegate void CustomerOperationEventHandler(object sender, CustomerEventArgs e);

    public class CustomerEventArgs : EventArgs
    {
        public Customer Customer { get; set; }
        public string Operation { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public CustomerEventArgs()
        {
            Timestamp = DateTime.UtcNow;
        }
    }

    // ========== SERVICE INTERFACES ==========

    public interface ICustomerService
    {
        event CustomerOperationEventHandler OnCustomerOperation;
        Task<PageResult<Customer>> GetCustomersAsync(SearchCriteria criteria, PaginationInfo pagination);
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid id);
        Task ActivateCustomerAsync(Guid id);
        Task DeactivateCustomerAsync(Guid id);
        Task<byte[]> ExportCustomersAsync(IEnumerable<Customer> customers, string format);
        Task<IEnumerable<Customer>> ImportCustomersAsync(byte[] fileData);
    }

    // ========== SERVICE IMPLEMENTATION ==========

    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IValidationService _validationService;

        public event CustomerOperationEventHandler OnCustomerOperation;

        public CustomerService(IRepository<Customer> customerRepository, IValidationService validationService)
        {
            _customerRepository = customerRepository;
            _validationService = validationService;
        }

        public async Task<PageResult<Customer>> GetCustomersAsync(SearchCriteria criteria, PaginationInfo pagination)
        {
            try
            {
                var allCustomers = await _customerRepository.GetAllAsync();

                // Apply search
                var query = ApplySearch(allCustomers.AsQueryable(), criteria);

                // Apply filter
                query = ApplyFilter(query, criteria.Filter);

                // Apply advanced search
                if (criteria.AdvancedOptions != null)
                    query = ApplyAdvancedSearch(query, criteria.AdvancedOptions);

                var totalItems = query.Count();
                var items = query.Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                                 .Take(pagination.PageSize)
                                 .ToList();

                pagination.TotalItems = totalItems;

                return new PageResult<Customer>
                {
                    Items = items,
                    Pagination = pagination
                };
            }
            catch (Exception ex)
            {
                throw new SystemException($"Error retrieving customers: {ex.Message}");
            }
        }

        private IQueryable<Customer> ApplySearch(IQueryable<Customer> query, SearchCriteria criteria)
        {
            if (string.IsNullOrWhiteSpace(criteria.SearchTerm))
                return query;

            switch (criteria.SearchMode)
            {
                case SearchMode.Contains:
                    return query.Where(c => c.CustomerNumber.Contains(criteria.SearchTerm) ||
                                           c.CustomerName.Contains(criteria.SearchTerm) ||
                                           c.PhoneNumber.Contains(criteria.SearchTerm));
                case SearchMode.StartsWith:
                    return query.Where(c => c.CustomerNumber.StartsWith(criteria.SearchTerm) ||
                                           c.CustomerName.StartsWith(criteria.SearchTerm) ||
                                           c.PhoneNumber.StartsWith(criteria.SearchTerm));
                case SearchMode.ExactMatch:
                    return query.Where(c => c.CustomerNumber == criteria.SearchTerm ||
                                           c.CustomerName == criteria.SearchTerm ||
                                           c.PhoneNumber == criteria.SearchTerm);
                default:
                    return query;
            }
        }

        private IQueryable<Customer> ApplyFilter(IQueryable<Customer> query, CustomerFilter filter)
        {
            if (filter == null) return query;

            if (filter.IsActive.HasValue)
                query = query.Where(c => c.IsActive == filter.IsActive.Value);

            if (filter.MinBalance.HasValue)
                query = query.Where(c => c.CurrentBalance >= filter.MinBalance.Value);

            if (filter.MaxBalance.HasValue)
                query = query.Where(c => c.CurrentBalance <= filter.MaxBalance.Value);

            if (filter.CreatedFrom.HasValue)
                query = query.Where(c => c.CreatedAt >= filter.CreatedFrom.Value);

            if (filter.CreatedTo.HasValue)
                query = query.Where(c => c.CreatedAt <= filter.CreatedTo.Value);

            return query;
        }

        private IQueryable<Customer> ApplyAdvancedSearch(IQueryable<Customer> query, AdvancedSearchOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.CustomerNumber))
                query = query.Where(c => c.CustomerNumber.Contains(options.CustomerNumber));

            if (!string.IsNullOrWhiteSpace(options.PhoneNumber))
                query = query.Where(c => c.PhoneNumber.Contains(options.PhoneNumber));

            return query;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new SystemException("Record not found.");
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await _validationService.ValidateCustomerAsync(customer);

            if (!await _validationService.IsPhoneNumberUniqueAsync(customer.PhoneNumber, customer.Id))
                throw new ValidationException("Phone number already exists.");

            customer.CustomerNumber = GenerateCustomerNumber();
            var created = await _customerRepository.AddAsync(customer);

            OnCustomerOperation?.Invoke(this, new CustomerEventArgs
            {
                Customer = created,
                Operation = "Create",
                Success = true,
                Message = "Customer added successfully."
            });

            return created;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var existing = await GetCustomerByIdAsync(customer.Id);
            existing.UpdateInfo(customer.CustomerName, customer.PhoneNumber);

            await _validationService.ValidateCustomerAsync(existing);

            if (!await _validationService.IsPhoneNumberUniqueAsync(existing.PhoneNumber, existing.Id))
                throw new ValidationException("Phone number already exists.");

            var updated = await _customerRepository.UpdateAsync(existing);

            OnCustomerOperation?.Invoke(this, new CustomerEventArgs
            {
                Customer = updated,
                Operation = "Update",
                Success = true,
                Message = "Customer updated successfully."
            });

            return updated;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await GetCustomerByIdAsync(id);
            await _customerRepository.DeleteAsync(id);

            OnCustomerOperation?.Invoke(this, new CustomerEventArgs
            {
                Customer = customer,
                Operation = "Delete",
                Success = true,
                Message = "Customer deleted successfully."
            });
        }

        public async Task ActivateCustomerAsync(Guid id)
        {
            var customer = await GetCustomerByIdAsync(id);
            customer.Activate();
            await _customerRepository.UpdateAsync(customer);

            OnCustomerOperation?.Invoke(this, new CustomerEventArgs
            {
                Customer = customer,
                Operation = "Activate",
                Success = true,
                Message = "Customer activated successfully."
            });
        }

        public async Task DeactivateCustomerAsync(Guid id)
        {
            var customer = await GetCustomerByIdAsync(id);
            customer.Deactivate();
            await _customerRepository.UpdateAsync(customer);

            OnCustomerOperation?.Invoke(this, new CustomerEventArgs
            {
                Customer = customer,
                Operation = "Deactivate",
                Success = true,
                Message = "Customer deactivated successfully."
            });
        }

        public async Task<byte[]> ExportCustomersAsync(IEnumerable<Customer> customers, string format)
        {
            // Implementation for export
            await Task.Delay(100);
            return new byte[0];
        }

        public async Task<IEnumerable<Customer>> ImportCustomersAsync(byte[] fileData)
        {
            // Implementation for import
            await Task.Delay(100);
            return new List<Customer>();
        }

        private string GenerateCustomerNumber()
        {
            return $"CUST-{DateTime.Now.Ticks}-{new Random().Next(1000, 9999)}";
        }
    }

    // ========== REPOSITORY PATTERN ==========

    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }

    public class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        private readonly Dictionary<Guid, T> _storage = new Dictionary<Guid, T>();

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_storage.Values.AsEnumerable());
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            _storage.TryGetValue(id, out var entity);
            return Task.FromResult(entity);
        }

        public Task<T> AddAsync(T entity)
        {
            _storage[entity.Id] = entity;
            return Task.FromResult(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            _storage[entity.Id] = entity;
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(Guid id)
        {
            _storage.Remove(id);
            return Task.CompletedTask;
        }
    }

    // ========== VALIDATION SERVICE ==========

    public interface IValidationService
    {
        Task ValidateCustomerAsync(Customer customer);
        Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber, Guid? excludeId = null);
    }

    public class ValidationService : IValidationService
    {
        private readonly IRepository<Customer> _customerRepository;

        public ValidationService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task ValidateCustomerAsync(Customer customer)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(customer.CustomerName))
                errors.Add("Customer name is required.");
            else if (customer.CustomerName.Length < 2)
                errors.Add("Customer name must be at least 2 characters.");
            else if (customer.CustomerName.Length > 100)
                errors.Add("Customer name cannot exceed 100 characters.");

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                errors.Add("Phone number is required.");
            else if (!System.Text.RegularExpressions.Regex.IsMatch(customer.PhoneNumber, @"^\+?[0-9]{10,15}$"))
                errors.Add("Invalid phone number format.");

            if (errors.Any())
                throw new ValidationException(string.Join(", ", errors));
        }

        public async Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber, Guid? excludeId = null)
        {
            var customers = await _customerRepository.GetAllAsync();
            return !customers.Any(c => c.PhoneNumber == phoneNumber && (!excludeId.HasValue || c.Id != excludeId.Value));
        }
    }

    // ========== VIEW MODELS ==========

    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
        public string Status => IsActive ? "Active" : "Inactive";

        public static CustomerViewModel FromCustomer(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                CustomerNumber = customer.CustomerNumber,
                CustomerName = customer.CustomerName,
                PhoneNumber = customer.PhoneNumber,
                CurrentBalance = customer.CurrentBalance,
                IsActive = customer.IsActive
            };
        }
    }

    // ========== TABLE COLUMN DEFINITION ==========

    public class TableColumn<T>
    {
        public string Title { get; set; }
        public string Field { get; set; }
        public int Width { get; set; }
        public string Alignment { get; set; }
        public bool IsVisible { get; set; }
        public bool IsSortable { get; set; }
        public bool IsFilterable { get; set; }
        public bool IsResizable { get; set; }
        public Func<T, object> ValueSelector { get; set; }

        public TableColumn()
        {
            IsVisible = true;
            IsSortable = true;
            IsFilterable = false;
            IsResizable = true;
            Width = 150;
            Alignment = "Left";
        }
    }

    // ========== PAGE STATES ==========

    public enum PageState
    {
        Loading,
        Loaded,
        Empty,
        Error
    }

    public enum FormState
    {
        Initial,
        Dirty,
        Valid,
        Invalid,
        Submitting,
        Saved,
        Failed
    }

    // ========== MAIN PAGE CONTROLLER ==========

    public class CustomerListPageController
    {
        private readonly ICustomerService _customerService;
        private List<CustomerViewModel> _customers;
        private PageState _currentState;
        private PaginationInfo _pagination;
        private SearchCriteria _currentSearchCriteria;

        public event EventHandler<PageStateChangedEventArgs> StateChanged;
        public event EventHandler<DataLoadedEventArgs> DataLoaded;
        public event EventHandler<string> ErrorOccurred;
        public event EventHandler<string> SuccessOccurred;

        public PageState CurrentState => _currentState;
        public IEnumerable<CustomerViewModel> Customers => _customers;
        public PaginationInfo Pagination => _pagination;

        public CustomerListPageController(ICustomerService customerService)
        {
            _customerService = customerService;
            _customers = new List<CustomerViewModel>();
            _pagination = new PaginationInfo { CurrentPage = 1, PageSize = 10 };
            _currentSearchCriteria = new SearchCriteria();
            _currentState = PageState.Loading;

            // Subscribe to service events
            _customerService.OnCustomerOperation += HandleCustomerOperation;
        }

        public async Task LoadDataAsync()
        {
            try
            {
                SetState(PageState.Loading);

                var result = await _customerService.GetCustomersAsync(_currentSearchCriteria, _pagination);

                _customers = result.Items.Select(CustomerViewModel.FromCustomer).ToList();
                _pagination = result.Pagination;

                SetState(_customers.Any() ? PageState.Loaded : PageState.Empty);
                DataLoaded?.Invoke(this, new DataLoadedEventArgs { ItemsCount = _customers.Count });
            }
            catch (SystemException ex)
            {
                SetState(PageState.Error);
                ErrorOccurred?.Invoke(this, ex.Message);
            }
        }

        public async Task SearchAsync(string searchTerm, SearchMode mode)
        {
            _currentSearchCriteria.SearchTerm = searchTerm;
            _currentSearchCriteria.SearchMode = mode;
            _pagination.CurrentPage = 1;
            await LoadDataAsync();
        }

        public async Task ApplyFilterAsync(CustomerFilter filter)
        {
            _currentSearchCriteria.Filter = filter;
            _pagination.CurrentPage = 1;
            await LoadDataAsync();
        }

        public async Task ClearFilterAsync()
        {
            _currentSearchCriteria.Filter = null;
            _pagination.CurrentPage = 1;
            await LoadDataAsync();
        }

        public async Task RefreshAsync()
        {
            await LoadDataAsync();
            SuccessOccurred?.Invoke(this, "Data refreshed successfully.");
        }

        public async Task ChangePageAsync(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > _pagination.TotalPages)
                return;

            _pagination.CurrentPage = pageNumber;
            await LoadDataAsync();
        }

        public async Task ChangePageSizeAsync(int pageSize)
        {
            _pagination.PageSize = pageSize;
            _pagination.CurrentPage = 1;
            await LoadDataAsync();
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(customerId);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
            }
        }

        public async Task BulkDeleteAsync(IEnumerable<Guid> customerIds)
        {
            foreach (var id in customerIds)
            {
                await DeleteCustomerAsync(id);
            }
            SuccessOccurred?.Invoke(this, $"{customerIds.Count()} customers deleted successfully.");
        }

        public async Task BulkActivateAsync(IEnumerable<Guid> customerIds)
        {
            foreach (var id in customerIds)
            {
                await _customerService.ActivateCustomerAsync(id);
            }
            await LoadDataAsync();
            SuccessOccurred?.Invoke(this, $"{customerIds.Count()} customers activated successfully.");
        }

        public async Task BulkDeactivateAsync(IEnumerable<Guid> customerIds)
        {
            foreach (var id in customerIds)
            {
                await _customerService.DeactivateCustomerAsync(id);
            }
            await LoadDataAsync();
            SuccessOccurred?.Invoke(this, $"{customerIds.Count()} customers deactivated successfully.");
        }

        private void SetState(PageState newState)
        {
            _currentState = newState;
            StateChanged?.Invoke(this, new PageStateChangedEventArgs { OldState = _currentState, NewState = newState });
        }

        private void HandleCustomerOperation(object sender, CustomerEventArgs e)
        {
            if (e.Success)
                SuccessOccurred?.Invoke(this, e.Message);
            else
                ErrorOccurred?.Invoke(this, e.Message);
        }
    }

    // ========== FORM CONTROLLER ==========

    public class CustomerFormController
    {
        private readonly ICustomerService _customerService;
        private Customer _currentCustomer;
        private FormState _currentState;
        private bool _isEditMode;

        public event EventHandler<FormStateChangedEventArgs> StateChanged;
        public event EventHandler<Customer> CustomerSaved;
        public event EventHandler<string> ValidationError;

        public FormState CurrentState => _currentState;
        public bool IsEditMode => _isEditMode;
        public Customer CurrentCustomer => _currentCustomer;

        public CustomerFormController(ICustomerService customerService)
        {
            _customerService = customerService;
            _currentState = FormState.Initial;
            _currentCustomer = new Customer();
        }

        public void InitializeForAdd()
        {
            _isEditMode = false;
            _currentCustomer = new Customer();
            _currentState = FormState.Initial;
            StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
        }

        public async Task InitializeForEditAsync(Guid customerId)
        {
            _isEditMode = true;
            _currentCustomer = await _customerService.GetCustomerByIdAsync(customerId);
            _currentState = FormState.Initial;
            StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
        }

        public void UpdateCustomerField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(Customer.CustomerName):
                    _currentCustomer.CustomerName = value?.ToString();
                    break;
                case nameof(Customer.PhoneNumber):
                    _currentCustomer.PhoneNumber = value?.ToString();
                    break;
            }

            _currentState = FormState.Dirty;
            StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
        }

        public async Task<bool> ValidateAsync()
        {
            try
            {
                var repository = new InMemoryRepository<Customer>();
                var validationService = new ValidationService(repository);
                await validationService.ValidateCustomerAsync(_currentCustomer);
                _currentState = FormState.Valid;
                StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
                return true;
            }
            catch (ValidationException ex)
            {
                _currentState = FormState.Invalid;
                StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
                ValidationError?.Invoke(this, ex.Message);
                return false;
            }
        }

        public async Task SaveAsync()
        {
            if (!await ValidateAsync())
                return;

            try
            {
                _currentState = FormState.Submitting;
                StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });

                Customer savedCustomer;
                if (_isEditMode)
                    savedCustomer = await _customerService.UpdateCustomerAsync(_currentCustomer);
                else
                    savedCustomer = await _customerService.CreateCustomerAsync(_currentCustomer);

                _currentState = FormState.Saved;
                StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
                CustomerSaved?.Invoke(this, savedCustomer);
            }
            catch (Exception ex)
            {
                _currentState = FormState.Failed;
                StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
                ValidationError?.Invoke(this, ex.Message);
            }
        }

        public void Cancel()
        {
            _currentState = FormState.Initial;
            StateChanged?.Invoke(this, new FormStateChangedEventArgs { NewState = _currentState });
        }
    }

    // ========== EVENT ARGUMENTS ==========

    public class PageStateChangedEventArgs : EventArgs
    {
        public PageState OldState { get; set; }
        public PageState NewState { get; set; }
    }

    public class FormStateChangedEventArgs : EventArgs
    {
        public FormState NewState { get; set; }
    }

    public class DataLoadedEventArgs : EventArgs
    {
        public int ItemsCount { get; set; }
    }

    // ========== TABLE HELPER ==========

    public class DataTable<T>
    {
        private List<TableColumn<T>> _columns;
        private List<T> _data;

        public IEnumerable<TableColumn<T>> Columns => _columns;
        public IEnumerable<T> Data => _data;
        public int TotalCount => _data.Count;

        public DataTable()
        {
            _columns = new List<TableColumn<T>>();
            _data = new List<T>();
        }

        public void AddColumn(TableColumn<T> column)
        {
            _columns.Add(column);
        }

        public void SetData(IEnumerable<T> data)
        {
            _data = data.ToList();
        }

        public IEnumerable<object> GetRowData(T item)
        {
            return _columns.Where(c => c.IsVisible).Select(c => c.ValueSelector?.Invoke(item) ?? GetPropertyValue(item, c.Field));
        }

        private object GetPropertyValue(T item, string propertyName)
        {
            var prop = typeof(T).GetProperty(propertyName);
            return prop?.GetValue(item);
        }
    }

    // ========== PROGRAM DEMONSTRATION ==========

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Customer Management System ===\n");

            // Setup dependencies
            var repository = new InMemoryRepository<Customer>();
            var validationService = new ValidationService(repository);
            var customerService = new CustomerService(repository, validationService);

            // Seed some data
            await SeedDataAsync(customerService);

            // Create page controller
            var pageController = new CustomerListPageController(customerService);

            // Subscribe to events
            pageController.StateChanged += (s, e) => Console.WriteLine($"Page State: {e.NewState}");
            pageController.DataLoaded += (s, e) => Console.WriteLine($"Loaded {e.ItemsCount} customers");
            pageController.ErrorOccurred += (s, e) => Console.WriteLine($"Error: {e}");
            pageController.SuccessOccurred += (s, e) => Console.WriteLine($"Success: {e}");

            // Load data
            await pageController.LoadDataAsync();

            // Display customers
            DisplayCustomers(pageController.Customers, pageController.Pagination);

            // Test search
            Console.WriteLine("\n--- Searching for 'John' ---");
            await pageController.SearchAsync("John", SearchMode.Contains);
            DisplayCustomers(pageController.Customers, pageController.Pagination);

            // Test form
            Console.WriteLine("\n--- Adding New Customer ---");
            var formController = new CustomerFormController(customerService);
            formController.InitializeForAdd();
            formController.UpdateCustomerField("CustomerName", "Test Customer");
            formController.UpdateCustomerField("PhoneNumber", "+1234567890");
            await formController.SaveAsync();

            // Refresh page
            await pageController.RefreshAsync();
            DisplayCustomers(pageController.Customers, pageController.Pagination);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static async Task SeedDataAsync(ICustomerService customerService)
        {
            // Using the constructor to set initial balance
            var customer1 = new Customer("John Doe", "+1234567890", 1000);
            var customer2 = new Customer("Jane Smith", "+1987654321", 2500);
            var customer3 = new Customer("Bob Johnson", "+1122334455", 500);

            await customerService.CreateCustomerAsync(customer1);
            await customerService.CreateCustomerAsync(customer2);
            await customerService.CreateCustomerAsync(customer3);
        }

        static void DisplayCustomers(IEnumerable<CustomerViewModel> customers, PaginationInfo pagination)
        {
            Console.WriteLine($"\nCustomer List (Page {pagination.CurrentPage} of {pagination.TotalPages})");
            Console.WriteLine("==================================================================================");
            Console.WriteLine($"{"Number",-15} {"Name",-20} {"Phone",-15} {"Balance",-12} {"Status"}");
            Console.WriteLine("==================================================================================");

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerNumber,-15} {customer.CustomerName,-20} {customer.PhoneNumber,-15} {customer.CurrentBalance,12:C} {customer.Status}");
            }

            Console.WriteLine("==================================================================================");
            Console.WriteLine($"Total Items: {pagination.TotalItems} | Page Size: {pagination.PageSize}");
            if (pagination.TotalPages > 0)
            {
                Console.WriteLine($"Page {pagination.CurrentPage} of {pagination.TotalPages}");
            }
        }
    }
}