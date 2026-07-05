using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abpCatalogPermissions
{


    // ModuleOrGroup.Entity.Permission
    public static class CatalogPermissions
    {
        public const string GroupName = "Catalog";


        public static class Products
        {
            public const string Default = GroupName + ".Products";

            public const string Create = Default + ".Create";
            public const string Read = Default + ".Read";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }


        public static class Categories
        {
            public const string Default = GroupName + ".Categories";

            public const string Create = Default + ".Create";
            public const string Read = Default + ".Read";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
