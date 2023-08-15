using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        IUserRepository UserRepository { get; set; }
        IMessageRepository MessageRepository { get; set; }
        IFriendRepository FriendRepository { get; set; }
        IWalletRepository WalletRepository { get; set; }
    }
}
