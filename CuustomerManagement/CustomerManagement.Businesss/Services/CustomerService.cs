using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Core.Entities;
using CustomerManagement.DataAccess.Context;

namespace CustomerManagement.Businesss.Services
{
    public class CustomerService
    {
        public void AddCustomer()
        {
        customerNameInput:
            Console.Write("Customerin adini daxil edin: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Adinizi duzgun daxil edin:");
                goto customerNameInput;
            }
        customerSurnameInput:
            Console.Write("Customerin soyadini daxil edin: ");
            string? surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Soyadinizi duzgun daxil edin");
                goto customerSurnameInput;
            }
        customerAgeInput:
            Console.Write("Customerin yasini daxil edin:");
            int age;
            Int32.TryParse(Console.ReadLine(), out age);
            if (age <= 0)
            {
                Console.WriteLine("Yasinizi duzgun daxil edin.Yas 0'dan boyuk olmalidir.");
                goto customerAgeInput;
            }
            Customer customer=new Customer(name,surname,age);
            Array.Resize(ref AppDbContext.customers, AppDbContext.customers.Length + 1);
            AppDbContext.customers[AppDbContext.customers.Length-1] = customer;
            Console.WriteLine("Yeni customer yaradildi.");
            customer.PrintPersonInfo();
        }
        public void ListAllCustomers()
        {
            Console.WriteLine("Customer Listesi");
            foreach (Customer customer in AppDbContext.customers)
            {
                customer.PrintPersonInfo();
            }
        }
        private Customer? ChooseCustomer()
        {
            ListAllCustomers();
            if (AppDbContext.customers.Length == 0)
            {
                return null;
            }
            Console.WriteLine("Secmek istediyiniz customerin Id-sini girin.");
            int customerId;
            Int32.TryParse(Console.ReadLine(),out customerId);
            Customer? foundCustomer=null;
            foreach (Customer customer in AppDbContext.customers)
            {
                if (customer.Id == customerId) { 
                    foundCustomer = customer;
                    break;
                }
            }
            if (foundCustomer != null) {
                Console.WriteLine("Axtarilan user melumatlari");
                foundCustomer.PrintPersonInfo();
                 }
            else
            {
                Console.WriteLine("Customer tapilmadi.");
            }
            return foundCustomer;
   


        }
        public void CustomerEdit()
        {
            Customer? foundCustomer = ChooseCustomer();
            if (foundCustomer == null)
            {
                return;
            }
        customerNameInput:
            Console.Write("Customerin yeni adini daxil edin: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Adinizi duzgun daxil edin:");
                goto customerNameInput;
            }
        customerSurnameInput:
            Console.Write("Customerin yeni soyadini daxil edin: ");
            string? surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Soyadinizi duzgun daxil edin");
                goto customerSurnameInput;
            }
        customerAgeInput:
            Console.Write("Customerin yeni yasini daxil edin:");
            int age;
            Int32.TryParse(Console.ReadLine(), out age);
            if (age <= 0)
            {
                Console.WriteLine("Yasinizi duzgun daxil edin.Yas 0'dan boyuk olmalidir.");
                goto customerAgeInput;
            }
            foundCustomer.Name=name;
            foundCustomer.Age=age;
            foundCustomer.Surname=surname;
            Console.WriteLine("Edit olundu");
            ListAllCustomers(); 

        }
        public void DeleteCostumer()
        {
            Customer? foundCustomer = ChooseCustomer();
            if (foundCustomer is null) { 
                return;
            }
            Customer[] filteredCustomers = new Customer[AppDbContext.customers.Length - 1];
            int idx = 0;
            foreach (Customer customer in AppDbContext.customers)
            {
                if (customer.Id!=foundCustomer.Id)
                {
                    filteredCustomers[idx]=customer;
                    idx++;
                }
            }
            AppDbContext.customers = filteredCustomers;
            Console.WriteLine("Customer silindi");
        }
        public void DoWalletOperations(WalletServices walletService) {
            Customer? foundCustomer = ChooseCustomer();
            if(foundCustomer  is null) { 
                return;
            }
            walletoperationsLabel:
            Console.WriteLine("Wallet emeliyyatlari");
            Console.WriteLine("1.Balans goster");
            Console.WriteLine("2.Medaxil et");
            Console.WriteLine("3.Mexaric et");
            Console.WriteLine("4.Transfer et");
            Console.WriteLine("5.Ana menyuya geri qayit");
            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    walletService.PrintBalance(foundCustomer.Wallet);
                    goto walletoperationsLabel;
                    break;   
                case 2:
                    increaseValueLabel:
                    Console.Write("Vesaiti daxil edin:");
                    double cashin;
                    double.TryParse(Console.ReadLine(), out cashin);
                    if (cashin==0)
                    {
                        Console.WriteLine("Duzgun daxil edin:");
                        goto increaseValueLabel;
                    }
                    walletService.IncreaseBalance(foundCustomer.Wallet, cashin);
                    goto walletoperationsLabel;
                case 3:
                decreaseValueLabel:
                    Console.Write("Vesaiti daxil edin:");
                    double cashout;
                    double.TryParse(Console.ReadLine(), out cashout);
                    if (cashout == 0)
                    {
                        Console.WriteLine("Duzgun daxil edin:");
                        goto decreaseValueLabel;
                    }
                    walletService.DecreaseBalance(foundCustomer.Wallet, cashout);
                    goto walletoperationsLabel;
                case 4:
                transferValueLabel:
                    Console.Write("Kocurmek istediyiniz vesaiti daxil edin:");
                    double transfervalue;
                    double.TryParse(Console.ReadLine(),out transfervalue);
                    if (transfervalue <= 0)
                    {
                        Console.WriteLine("Mebleg 0-dan boyuk olmalidir.Duzgun daxil edin:");
                        goto transferValueLabel;
                    }
                    walletService.TransferToOtherUser(foundCustomer.Wallet, transfervalue);
                    Console.WriteLine("Customer Listesi");
                    foreach (Customer customer in AppDbContext.customers)
                    {
                        customer.PrintPersonInfo();
                    }
                RetryIdEnter:
                    Console.WriteLine("Transfer edeceyiniz hesabin Id-sini daxil edin.");
                    int newuserId;
                    Int32.TryParse(Console.ReadLine(), out newuserId);
                    if (newuserId <= 0)
                    {
                        Console.WriteLine("User Tapilmadi.Duzgun Id daxil edin.");
                        goto RetryIdEnter;
                    }
                   // Customer? nevId = ChooseCustomer();
                    foreach (Customer customer in AppDbContext.customers) {
                        if (customer.Id==newuserId)
                        {
                            Console.WriteLine("Eyni hesablar arasinda kocurme mumkun deyil.");
                        }
                        else
                        {
                            customer.Wallet.Balance-=transfervalue;
                            customer.Id=newuserId;
                        }
                        Console.WriteLine("Balance:",customer.Wallet.Balance);
                    }
                    goto walletoperationsLabel;
                case 5:
                    break;
                default:
                    goto walletoperationsLabel;
            }

        }
    }
}
