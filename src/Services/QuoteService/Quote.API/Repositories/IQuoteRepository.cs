using Quote.API.Dtos;

namespace Quote.API.Repositories
{
    public interface IQuoteRepository
    {
        List<Entities.Quote> GetAll();
        Task<Entities.Quote> GetByIdAsync(int id);

        void DeleteQuote(int id);
        Task<bool> CreateQuoteAsync(Entities.Quote quote);
        bool UpdateQuote(Entities.Quote quote);

        Task SaveAsync();
    }
}
