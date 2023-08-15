using BitTrade.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.Common.Models
{
    public class WalletModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CoinCount { get; set; }
        public string CurrencyType { get; set; }

    }
}