using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPersonalInfoModeling
{
    public static class InputMessages
    {

    }

    public static class OutputMessages
    {

    }

    public static class Formatting
    {

    }

    public static class Validator
    {

    }
    public static class InputHelper
    {

    }

    public static class OutputHelper
    {

    }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}


namespace PersonalInfoModeling
{
    public enum Gender
    {
        None,
        Male,
        Female
    }

    public enum MaritalStatus
    {
        Single,
        Married,
        Widowed
    }

    public enum PhoneType
    {
        Mobile,
        Home,
        Work
    }


    public class Person
    {
        public Guid Id { get; set; }
        public FullName Name { get; set; }
    }

    public class PhysicalInfo
    {
        public double Height { get; set; }
        public double Weight { get; set; }
    }
    public class FullName
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string Suffix { get; set; }
        public string Nickname { get; set; }
    }

    public class WorkInfo
    {
        public string Organization { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City{ get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

    }

    public class Phone
    {
        public string CodeCountry { get; set; }
        public string Number { get; set; }
        public PhoneType Type { get; set; }
    }

    public class Email
    {
        public string EmailValue { get; set; }
    }

    public struct Contact
    {
        public string PhoneNumber;
        public string MobileNumber;
        public string PrimaryEmail;
        public string SecondaryEmail;
    }

}
