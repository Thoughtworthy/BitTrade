using BitTrade.BLL.Extensions;
using BitTrade.Common.Helpers;
using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BitTrade.BLL.Services
{
    public class WalletService : IWalletService
    {

        private readonly IUnitOfWork _unitOfWork;

        public WalletService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<WalletModel> GetWalletByID(int id)
        {
            var wallet = _unitOfWork.WalletRepository.Get(w => w.UserID ==  id);

            if (wallet == null)
            {
                return new List<WalletModel>();
            }
            var wallets = wallet.MapTo<WalletModel>();

            return wallets;

        }

        public void Update(WalletModel model)
        {
            throw new NotImplementedException();
        }
    }
}
