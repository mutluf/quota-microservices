using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quote.API.Context;

namespace Quote.API.Repositories
{
    public class QuoteRepository:IQuoteRepository
    {
        private readonly QuotaQuoteDbContext _context;

        public QuoteRepository(QuotaQuoteDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateQuoteAsync(Entities.Quote quote)
        {
            EntityEntry entry = await _context.Quotes.AddAsync(quote);

            return entry.State == EntityState.Added;
        }

        public void DeleteQuote(int id)
        {
            _context.Remove(id);
        }

        public List<Entities.Quote> GetAll()
        {
            return _context.Quotes.AsQueryable().ToList();           
        }

        public async Task<Entities.Quote> GetByIdAsync(int id)
        {
            Entities.Quote quote = await _context.Quotes.FirstOrDefaultAsync(r=>r.Id==id);
            return quote;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool UpdateQuote(Entities.Quote quote)
        {
            EntityEntry entry =  _context.Quotes.Update(quote);

            return entry.State == EntityState.Added;
        }
    }
}
