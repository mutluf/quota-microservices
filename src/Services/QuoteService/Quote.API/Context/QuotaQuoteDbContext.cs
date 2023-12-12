using Microsoft.EntityFrameworkCore;

namespace Quote.API.Context
{
    public class QuotaQuoteDbContext : DbContext
    {
        public QuotaQuoteDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Quote> Quotes { get; set; }
    }
}
