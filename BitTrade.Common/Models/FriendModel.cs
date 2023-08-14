using BitTrade.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.Common.Models
{
    public class FriendModel
    {
        public int ID { get; set; }
        public int FromUserID { get; set; }
        public int ToUserID { get; set; }
        public System.DateTime Date { get; set; }
    }
}