using Microsoft.EntityFrameworkCore;
using Quota.Aggregator.Models;

namespace Quota.Aggregator.Context
{
    public class AggregatorDbContext : DbContext
    {
        public AggregatorDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserQuote> UserQuotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserQuote>().
                HasKey(x => new
                {
                    x.Username,
                    x.QuoteId
                });
        }
    }
}
