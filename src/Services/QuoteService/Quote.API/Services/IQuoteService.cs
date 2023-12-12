using Quote.API.Dtos;

namespace Quote.API.Services
{
    public interface IQuoteService
    {
        List<QuoteDto> GetAll();
        Task<QuoteDto> GetByIdAsync(int id);

        void Delete(int id);
        Task<bool> CreateAsync(QuoteDto quote);
        bool Update(QuoteDto quote);

    }
}
