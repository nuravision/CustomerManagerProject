using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManageement.Core.Entities
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        private static int count = 0;
        public Customer(string name,string surname,int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Id = ++count;
        }
    }
}
