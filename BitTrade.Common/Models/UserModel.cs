using BitTrade.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.Common.Models
{
    public class UserModel
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public BaseGenderEnum Gender { get; set; } = BaseGenderEnum.Unknown;
        public BaseRoleEnum Role { get; set; } = BaseRoleEnum.user;
        public bool IsActive { get; set; } = true;
        public string ImageURL { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
