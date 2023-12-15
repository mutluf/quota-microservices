using Microsoft.EntityFrameworkCore;
using Quota.Aggregator.Context;
using Quota.Aggregator.Models;

namespace Quota.Aggregator.Repositories
{
    public class UserQuoteRepository : IUserQuoteRepository
    {
        private readonly AggregatorDbContext _context;

        public UserQuoteRepository(AggregatorDbContext context)
        {
            _context = context;
        }

        public DbSet<UserQuote> Table => _context.Set<UserQuote>();


        public async Task<bool> CreateQuoteAsync(UserQuote userQuote)
        {
            UserQuote data = new()
            {
                Username = userQuote.Username,
                QuoteId = userQuote.QuoteId
            };

            var entry = await _context.AddAsync(data);

            return entry.State == EntityState.Added;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
