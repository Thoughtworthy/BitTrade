using BitTrade.DAL.Interfaces;
using System;
using System.Data.Entity;

namespace BitTrade.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly TradeEntities DbContext;
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(TradeEntities tradeEntities)
        {
            DbContext = tradeEntities;
            UserRepository = new UserRepository(tradeEntities);
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
