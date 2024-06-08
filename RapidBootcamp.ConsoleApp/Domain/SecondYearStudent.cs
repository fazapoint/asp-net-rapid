using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.Domain
{
    public class SecondYearStudent : Student
    {
        public string? Major { get; set; }
        public string? Class { get; set; }

        override public string GetInfo()
        {
            return $"Name: {FullName}, Address: {Address}, Phone: {PhoneNumber}, Nim: {Nim}, IPK: {IPK}, Major: {Major}, Class: {Class}";
        }
    }
}
