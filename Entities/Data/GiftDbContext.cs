using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Data
{
    public class GiftDbContext : DbContext
    {

        public GiftDbContext(DbContextOptions<GiftDbContext> options) : base(options)
        {
        }

        public DbSet<Gift> Gifts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gift>().Property(x => x.Timestamp).IsRowVersion();
        }
    }
}
