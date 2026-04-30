using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

// For JSON - using simple manual serialization to avoid System.Text.Json
// If you have Newtonsoft.Json available, that's better. This uses manual string building.

namespace StrategyPatternStudentSys
{
    // ======================== MODEL ========================
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0,-3} | Name: {1,-15} | Age: {2} | Major: {3,-12} | GPA: {4:F2} | Email: {5}",
                Id, Name, Age, Major, GPA, Email);
        }
    }







  
    public interface IExporter
    {
        void Export(List<Student> students, string filePath);
        string GetFileExtension();
    }

    public class JsonExporter : IExporter
    {
        public void Export(List<Student> students, string filePath)
        {
          
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");

            for (int i = 0; i < students.Count; i++)
            {
                var s = students[i];
                sb.AppendLine("  {");
                sb.AppendLine(string.Format("    \"Id\": {0},", s.Id));
                sb.AppendLine(string.Format("    \"Name\": \"{0}\",", EscapeJson(s.Name)));
                sb.AppendLine(string.Format("    \"Age\": {0},", s.Age));
                sb.AppendLine(string.Format("    \"Major\": \"{0}\",", EscapeJson(s.Major)));
                sb.AppendLine(string.Format("    \"GPA\": {0},", s.GPA.ToString(System.Globalization.CultureInfo.InvariantCulture)));
                sb.AppendLine(string.Format("    \"Email\": \"{0}\"", EscapeJson(s.Email)));
                sb.Append("  }");
                if (i < students.Count - 1) sb.Append(",");
                sb.AppendLine();
            }
            sb.AppendLine("]");

            File.WriteAllText(filePath, sb.ToString());
        }

        private string EscapeJson(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        public string GetFileExtension() { return "json"; }
    }

    public class CsvExporter : IExporter
    {
        public void Export(List<Student> students, string filePath)
        {
            List<string> lines = new List<string>();
            // Header
            lines.Add("Id,Name,Age,Major,GPA,Email");
            // Data
            foreach (var student in students)
            {
                lines.Add(string.Format("{0},{1},{2},{3},{4},{5}",
                    student.Id, student.Name, student.Age, student.Major,
                    student.GPA.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    student.Email));
            }
            File.WriteAllLines(filePath, lines);
        }

        public string GetFileExtension() { return "csv"; }
    }

    public class XmlExporter : IExporter
    {
        public void Export(List<Student> students, string filePath)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Students");

            foreach (var s in students)
            {
                XElement studentElem = new XElement("Student",
                    new XElement("Id", s.Id),
                    new XElement("Name", s.Name),
                    new XElement("Age", s.Age),
                    new XElement("Major", s.Major),
                    new XElement("GPA", s.GPA),
                    new XElement("Email", s.Email)
                );
                root.Add(studentElem);
            }

            doc.Add(root);
            doc.Save(filePath);
        }

        public string GetFileExtension() { return "xml"; }
    }

   
    public static class ExporterFactory
    {
        public static IExporter Create(string format)
        {
            string lowerFormat = format.ToLower();

            if (lowerFormat == "json")
            {
                return new JsonExporter();
            }
            else if (lowerFormat == "csv")
            {
                return new CsvExporter();
            }
            else if (lowerFormat == "xml")
            {
                return new XmlExporter();
            }
            else
            {
                throw new ArgumentException("Unsupported format: " + format + ". Supported: json, csv, xml");
            }
        }
    }

  



















    public class StudentService
    {
        private List<Student> _students;
        private int _nextId;

        public StudentService()
        {
            _students = new List<Student>();
            _nextId = 1;
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            Student s1 = new Student();
            s1.Id = _nextId++; s1.Name = "Ahmed Mansour"; s1.Age = 22; s1.Major = "Computer Science"; s1.GPA = 3.8; s1.Email = "ahmed@uni.edu";
            _students.Add(s1);

            Student s2 = new Student();
            s2.Id = _nextId++; s2.Name = "Fatima Al-Zahra"; s2.Age = 21; s2.Major = "Engineering"; s2.GPA = 3.9; s2.Email = "fatima@uni.edu";
            _students.Add(s2);

            Student s3 = new Student();
            s3.Id = _nextId++; s3.Name = "Youssef Haddad"; s3.Age = 23; s3.Major = "Mathematics"; s3.GPA = 3.5; s3.Email = "youssef@uni.edu";
            _students.Add(s3);

            Student s4 = new Student();
            s4.Id = _nextId++; s4.Name = "Layla Khalil"; s4.Age = 20; s4.Major = "Physics"; s4.GPA = 3.7; s4.Email = "layla@uni.edu";
            _students.Add(s4);

            Student s5 = new Student();
            s5.Id = _nextId++; s5.Name = "Omar Farouk"; s5.Age = 24; s5.Major = "Computer Science"; s5.GPA = 2.9; s5.Email = "omar@uni.edu";
            _students.Add(s5);
        }

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            student.Id = _nextId++;
            _students.Add(student);
            Console.WriteLine("✓ Student '" + student.Name + "' added successfully with ID: " + student.Id);
        }

        public bool UpdateStudent(int id, Student updatedStudent)
        {
            Student student = GetStudentById(id);
            if (student == null) return false;

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Major = updatedStudent.Major;
            student.GPA = updatedStudent.GPA;
            student.Email = updatedStudent.Email;
            return true;
        }

        public bool DeleteStudent(int id)
        {
            Student student = GetStudentById(id);
            if (student == null) return false;
            return _students.Remove(student);
        }

        // LINQ Operations
        public List<Student> SearchByName(string keyword)
        {
            return _students.Where(s => s.Name.ToLower().Contains(keyword.ToLower())).ToList();
        }

        public List<Student> GetStudentsByMajor(string major)
        {
            return _students.Where(s => s.Major.ToLower().Equals(major.ToLower())).ToList();
        }

        public List<Student> GetHonorsStudents(double minGPA)
        {
            return _students.Where(s => s.GPA >= minGPA).OrderByDescending(s => s.GPA).ToList();
        }

        public Dictionary<string, List<Student>> GroupByMajor()
        {
            return _students.GroupBy(s => s.Major).ToDictionary(g => g.Key, g => g.ToList());
        }

        public double GetAverageGPA()
        {
            if (_students.Count == 0) return 0;
            return _students.Average(s => s.GPA);
        }

        public Student GetTopStudent()
        {
            return _students.OrderByDescending(s => s.GPA).FirstOrDefault();
        }

        public List<Student> GetStudentsByAgeRange(int minAge, int maxAge)
        {
            return _students.Where(s => s.Age >= minAge && s.Age <= maxAge).OrderBy(s => s.Age).ToList();
        }

        // Export using Strategy Pattern
        public void ExportStudents(string format, string filePath)
        {
            try
            {
                IExporter exporter = ExporterFactory.Create(format);
                exporter.Export(_students, filePath);
                Console.WriteLine("✓ Successfully exported " + _students.Count + " students to '" + filePath + "' in " + format.ToUpper() + " format");
            }
            catch (Exception ex)
            {
                Console.WriteLine("✗ Export failed: " + ex.Message);
            }
        }
    }

    // ======================== CONSOLE MENU ========================
    class Program
    {
        private static StudentService _service = new StudentService();

        static void Main(string[] args)
        {
            Console.Title = "Student Management System";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║     STUDENT MANAGEMENT SYSTEM         ║");
            Console.WriteLine("║   OOP | SOLID | LINQ | Strategy       ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();

            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllStudents();
                        break;
                    case "2":
                        AddStudent();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        SearchStudents();
                        break;
                    case "6":
                        FilterByMajor();
                        break;
                    case "7":
                        ShowHonorsStudents();
                        break;
                    case "8":
                        ShowStatistics();
                        break;
                    case "9":
                        GroupByMajorAndDisplay();
                        break;
                    case "10":
                        ExportMenu();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("\n👋 Thank you for using the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("✗ Invalid option. Please try again.");
                        break;
                }

                if (running && choice != "0")
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n══════════════════════════════════════════");
            Console.WriteLine("                 MAIN MENU                 ");
            Console.WriteLine("══════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine("1. 📋 Display All Students");
            Console.WriteLine("2. ➕ Add New Student");
            Console.WriteLine("3. ✏️  Update Student");
            Console.WriteLine("4. 🗑️  Delete Student");
            Console.WriteLine("5. 🔍 Search Students by Name");
            Console.WriteLine("6. 📚 Filter Students by Major");
            Console.WriteLine("7. 🎓 Show Honors Students (GPA ≥ 3.5)");
            Console.WriteLine("8. 📊 Show Statistics");
            Console.WriteLine("9. 📁 Group Students by Major");
            Console.WriteLine("10. 💾 Export Students (JSON/CSV/XML)");
            Console.WriteLine("0. 🚪 Exit");
            Console.Write("\n👉 Select an option: ");
        }

        static void DisplayAllStudents()
        {
            List<Student> students = _service.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("\n⚠️ No students found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n═══════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                                    STUDENTS                                   ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\n📊 Total: " + students.Count + " students");
        }

        static void AddStudent()
        {
            Console.WriteLine("\n--- Add New Student ---");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Major: ");
            string major = Console.ReadLine();

            Console.Write("GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Student student = new Student();
            student.Name = name;
            student.Age = age;
            student.Major = major;
            student.GPA = gpa;
            student.Email = email;

            _service.AddStudent(student);
        }

        static void UpdateStudent()
        {
            Console.Write("\nEnter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Student existing = _service.GetStudentById(id);
            if (existing == null)
            {
                Console.WriteLine("✗ Student not found.");
                return;
            }

            Console.WriteLine("\nUpdating: " + existing);
            Console.WriteLine("(Press Enter to keep current value)");

            Console.Write("Name [" + existing.Name + "]: ");
            string name = Console.ReadLine();

            Console.Write("Age [" + existing.Age + "]: ");
            string ageInput = Console.ReadLine();

            Console.Write("Major [" + existing.Major + "]: ");
            string major = Console.ReadLine();

            Console.Write("GPA [" + existing.GPA + "]: ");
            string gpaInput = Console.ReadLine();

            Console.Write("Email [" + existing.Email + "]: ");
            string email = Console.ReadLine();

            Student updated = new Student();
            updated.Name = (string.IsNullOrWhiteSpace(name)) ? existing.Name : name;
            updated.Age = (string.IsNullOrWhiteSpace(ageInput)) ? existing.Age : int.Parse(ageInput);
            updated.Major = (string.IsNullOrWhiteSpace(major)) ? existing.Major : major;
            updated.GPA = (string.IsNullOrWhiteSpace(gpaInput)) ? existing.GPA : double.Parse(gpaInput);
            updated.Email = (string.IsNullOrWhiteSpace(email)) ? existing.Email : email;

            if (_service.UpdateStudent(id, updated))
                Console.WriteLine("✓ Student updated successfully!");
        }

        static void DeleteStudent()
        {
            Console.Write("\nEnter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            if (_service.DeleteStudent(id))
                Console.WriteLine("✓ Student deleted successfully!");
            else
                Console.WriteLine("✗ Student not found.");
        }

        static void SearchStudents()
        {
            Console.Write("\nEnter name keyword: ");
            string keyword = Console.ReadLine();

            List<Student> results = _service.SearchByName(keyword);
            if (results.Count == 0)
            {
                Console.WriteLine("⚠️ No students found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n🔍 Search Results (" + results.Count + " found):");
            Console.ResetColor();
            foreach (Student student in results)
            {
                Console.WriteLine(student);
            }
        }

        static void FilterByMajor()
        {
            Console.Write("\nEnter major (Computer Science, Engineering, Mathematics, Physics): ");
            string major = Console.ReadLine();

            List<Student> results = _service.GetStudentsByMajor(major);
            if (results.Count == 0)
            {
                Console.WriteLine("⚠️ No students found with major: " + major);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📚 Students in " + major + " (" + results.Count + " found):");
            Console.ResetColor();
            foreach (Student student in results)
            {
                Console.WriteLine(student);
            }
        }

        static void ShowHonorsStudents()
        {
            List<Student> honors = _service.GetHonorsStudents(3.5);
            if (honors.Count == 0)
            {
                Console.WriteLine("\n⚠️ No honors students (GPA ≥ 3.5)");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n🎓 HONORS STUDENTS (GPA ≥ 3.5)");
            Console.ResetColor();
            foreach (Student student in honors)
            {
                Console.WriteLine(student);
            }
        }

        static void ShowStatistics()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n══════════════════════════════════════════");
            Console.WriteLine("              STATISTICS DASHBOARD          ");
            Console.WriteLine("══════════════════════════════════════════");
            Console.ResetColor();

            List<Student> all = _service.GetAllStudents();
            Console.WriteLine("\n📊 Total Students: " + all.Count);
            Console.WriteLine("📈 Average GPA: " + _service.GetAverageGPA().ToString("F2"));

            Student topStudent = _service.GetTopStudent();
            if (topStudent != null)
                Console.WriteLine("🏆 Top Student: " + topStudent.Name + " (GPA: " + topStudent.GPA.ToString("F2") + ")");

            int honorsCount = _service.GetHonorsStudents(3.5).Count;
            Console.WriteLine("🎓 Honors Students (GPA ≥ 3.5): " + honorsCount);

            List<Student> ageGroups = _service.GetStudentsByAgeRange(20, 22);
            Console.WriteLine("👥 Students aged 20-22: " + ageGroups.Count);

            Console.WriteLine("\n📚 Students per Major:");
            Dictionary<string, List<Student>> groups = _service.GroupByMajor();
            foreach (KeyValuePair<string, List<Student>> group in groups)
            {
                Console.WriteLine("   • " + group.Key + ": " + group.Value.Count + " students");
            }
        }

        static void GroupByMajorAndDisplay()
        {
            Dictionary<string, List<Student>> groups = _service.GroupByMajor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n══════════════════════════════════════════");
            Console.WriteLine("           STUDENTS GROUPED BY MAJOR        ");
            Console.WriteLine("══════════════════════════════════════════");
            Console.ResetColor();

            foreach (KeyValuePair<string, List<Student>> group in groups)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n📖 " + group.Key + " (" + group.Value.Count + " students):");
                Console.ResetColor();
                foreach (Student student in group.Value)
                {
                    Console.WriteLine("   • " + student.Name + " (GPA: " + student.GPA.ToString("F2") + ")");
                }
            }
        }

        static void ExportMenu()
        {
            Console.WriteLine("\n--- Export Students ---");
            Console.WriteLine("Available formats: json, csv, xml");
            Console.Write("Choose format: ");
            string format = Console.ReadLine().ToLower();

            Console.Write("Enter file path (e.g., C:\\temp\\students or students): ");
            string path = Console.ReadLine();

            // Add extension if not provided
            string extension = ".txt";
            if (format == "json") extension = ".json";
            else if (format == "csv") extension = ".csv";
            else if (format == "xml") extension = ".xml";

            string fullPath = path;
            if (!path.Contains("."))
                fullPath = path + extension;

            _service.ExportStudents(format, fullPath);
        }
    }
}