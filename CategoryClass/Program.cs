using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryClass
{




   public class Customer
    {

        public virtual ICollection<Order> orders { get; protected set; }

        protected Customer()
        {
            orders = new Collection<Order>();
        }
    }

    public class Order
    {

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }

   public class Category
    {
        public Guid ID { get; private set; }
        public string NameAr { get; private set; }
        public string NameEn { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime  DeletedAt { get; private set; }
        public bool IsActive { get; private set; } = true;


        public virtual ICollection<Product> products { get; protected set; }

        protected Category()
        {
            products = new Collection<Product>();
        }
        // setters 
        //business behavior
        //private Category()
        //{

        //}


        ////protected Category()
        ////{

        ////}

        //public Category(Guid id, string nameAr,bool isActive = true )
        //{
        //    this.ID = id;
        //    this.NameAr = nameAr;
        //    this.IsActive = isActive;
        //}
    }

    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; private set; }
        public Guid CategoryID { get; private set; }
        public Category Category { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
