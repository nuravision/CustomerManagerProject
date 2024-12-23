using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Customer:BaseEntity
    {
        public Wallet Wallet { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        private static int Count { get; set; }
        public Customer(string name,string surname,int age)
        {
            Id = ++Count;
            Name = name;
            Surname = surname;
            Age = age;
            Wallet = new Wallet();
        }
        public void PrintPersonWalletBalance()
        {
            Console.WriteLine($"Balance: {Wallet.Balance}");
        }
        public void PrintPersonInfo()
        {
            Console.WriteLine($"{Id}: {Name} {Surname} {Age}");
        }
    }
}
