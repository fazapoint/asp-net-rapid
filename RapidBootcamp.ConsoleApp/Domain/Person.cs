using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RapidBootcamp.ConsoleApp.Domain
{
    public abstract class Person
    {
        public Person()
        {

        }

        public Person(string fullname, string address, string phonenumber)
        {
            this.FullName = fullname;
            this.Address = address;
            this.PhoneNumber = phonenumber;
        }

        //protected int Id { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual string GetInfo()
        {
            return $"Name: {FullName}, Address: {Address}, Phone: {PhoneNumber}";
        }

        public abstract void Save();
        public abstract void Load();
        public abstract string GetFullName();
    }
}
