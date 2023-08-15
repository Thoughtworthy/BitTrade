using BitTrade.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.Common.Models
{
    public class CurrencyModel
    {
        public decimal Price { get; set; }
        public string Exchange { get; set; }
        public string Pair { get; set; }
        public decimal PairPrice { get; set; }
        public decimal Volume { get; set; }

    }
}