using BitTrade.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.Common.Models
{
    public class FriendShipModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsFriend { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}