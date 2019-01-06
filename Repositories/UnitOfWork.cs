using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities.Data;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GiftDbContext _db;
        public UnitOfWork(GiftDbContext db)
        {
            _db = db;
            GiftRepository = new GiftRepository(_db);
        }
        public IGiftRepository GiftRepository { get; }

        public int Complete()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
