using BitTrade.DAL.Interfaces;
using System;
using System.Data.Entity;

namespace BitTrade.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly TradeEntities _dbContext;
        public IUserRepository _userRepository { get; set; }

        public UnitOfWork()
        {
            _dbContext = new TradeEntities();
            _userRepository = new UserRepository(_dbContext);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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
