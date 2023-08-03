using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.DAL
{
    public class UserRepository
    {
        public static List<User> GetUsers()
        {
            var users = new List<User>();

            using (var DB = new TradeEntities())
            {
                users = DB.Users.AsNoTracking().Select(u => u).ToList();
            }

            return users;
        }
    }
}
