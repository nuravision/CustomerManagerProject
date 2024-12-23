using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Core.Entities;
using CustomerManagement.Businesss.Services;
using CustomerManagement.DataAccess.Context;

namespace CustomerManagement.Businesss.Services
{
    public class WalletServices
    {
        public void PrintBalance(Wallet wallet)
        {
            Console.WriteLine($"Wallet balance:" + wallet.Balance);
        }
        public void IncreaseBalance(Wallet wallet,double value) {
            if (value<=0) {
                Console.WriteLine("Vesait 0-dan boyuk olmalidir.");
                return;
            }
            wallet.Balance += value;
            Console.WriteLine("Balansa medaxil edildi: ",+value);
        }
        public void DecreaseBalance(Wallet wallet, double value)
        {
            if (value>wallet.Balance)
            {
            Console.WriteLine("Istenilen vesait balancede yoxdur.");
            return;
            }
            if (value<0)
            {
                Console.WriteLine("Vesait 0-dan boyuk olmalidir.");
                return;
            }
            wallet.Balance -= value;
            Console.WriteLine("Balansdan mexaric edildi:",+value);
        }
        public void TransferToOtherUser(Wallet wallet,double money) {
            
        }
        

    }
}
