using Quote.API.Dtos;

namespace Quote.API.Repositories
{
    public interface IQuoteRepository
    {
        Task<List<QuoteDto>> GetAll();
        Task<QuoteDto> GetById(int id);

        void DeleteQuote(int id);
        Task<bool> CreateQuote(QuoteDto quote);
        Task<QuoteDto> UpdateQuote(QuoteDto quote);

        Task SaveAsync();
    }
}
