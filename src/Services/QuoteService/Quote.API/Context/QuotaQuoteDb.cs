using Microsoft.EntityFrameworkCore;

namespace Quote.API.Context
{
    public class QuotaQuoteDb : DbContext
    {
        public QuotaQuoteDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Quote> Quotes { get; set; }
    }
}
