using CustomerManagement.Businesss.Services;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Concurrent;

CustomerService customerService = new CustomerService();
WalletServices walletService = new WalletServices();

bool isContiniue = true;
Console.WriteLine("Xos gelmisiniz.");
while (isContiniue)
{
    Console.WriteLine("Asagidakilardan birini secin.");
    Console.WriteLine("1.Customer yaradin.");
    Console.WriteLine("2.Customer-leri listeleyin.");
    Console.WriteLine("3.Customeri Redakte edin.");
    Console.WriteLine("4.Customeri silin.");
    Console.WriteLine("5.Wallat emeliyyatlari.");
    Console.WriteLine("6.Programdan cixin.");
    int choice;
    Int32.TryParse(Console.ReadLine(), out choice);
    switch (choice)
    {
        case 1:
            customerService.AddCustomer();
            break;
        case 2:
            customerService.ListAllCustomers();
            break;
        case 3:
            customerService.CustomerEdit();
            break;
        case 4:
            customerService.DeleteCostumer();
            break;
        case 5:
            customerService.DoWalletOperations(walletService);
            break;
        case 6:
            isContiniue = false;
            Console.WriteLine("Program bitti.Yaxsi yol.");
            break;
        default: 
            Console.WriteLine("Duzgun giris edin.");
            break;
    }
}