using BitTrade.Common.Models;
using System.Collections.Generic;

namespace BitTrade.BLL.Services
{
    public interface IWalletService
    {
        void Update(WalletModel model);
        IEnumerable<WalletModel> GetWalletByID(int id);
    }
}
