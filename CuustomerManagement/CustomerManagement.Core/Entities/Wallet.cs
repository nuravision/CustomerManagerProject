using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Entities
{
    public class Wallet
    {
        public double Balance { get; set; }
        public Wallet()
        {
            Balance = 0;
        }

    }
}
