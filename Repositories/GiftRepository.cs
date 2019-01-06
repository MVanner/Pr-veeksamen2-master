using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Entities.Data;

namespace Repositories
{
    internal class GiftRepository : Repository<Gift>, IGiftRepository
    {
        public GiftRepository(GiftDbContext db) : base(db)
        {
        }
    }
}