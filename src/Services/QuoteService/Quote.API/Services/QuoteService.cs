using Quote.API.Dtos;
using Quote.API.Repositories;

namespace Quote.API.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public Task<bool> CreateAsync(QuoteDto quote)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuoteDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<QuoteDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(QuoteDto quote)
        {
            throw new NotImplementedException();
        }
    }
}
