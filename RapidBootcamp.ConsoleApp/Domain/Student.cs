using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.Domain
{
    public class Student : Person, ICrud, IStorable, IPrintable
    {
        public Student()
        {

        }

        public Student(string fullname, string address, string phonenumber, string nim, double ipk)
            : base(fullname, address, phonenumber)
        {
            this.Nim = nim;
            this.IPK = ipk;
        }

        public string? Nim { get; set; }
        public double IPK { get; set; }

        public double GetIPK()
        {
            return IPK;
        }

        public override string GetInfo()
        {
            return $"Name: {FullName}, Address: {Address}, Phone: {PhoneNumber}, Nim: {Nim}, IPK: {IPK}";
        }

        public override void Save()
        {
            Console.WriteLine("Save from Student");
        }

        public override void Load()
        {
            Console.WriteLine("Load from Student");
        }

        public override string GetFullName()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            Console.WriteLine("Insert from Student");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Select()
        {
            throw new NotImplementedException();
        }

        public void Store()
        {
            Console.WriteLine("Store from Student");
        }

        public void Print()
        {
            Console.WriteLine("Print from Student");
        }
    }
}
