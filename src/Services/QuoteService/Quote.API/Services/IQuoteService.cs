using Quote.API.Dtos;

namespace Quote.API.Services
{
    public interface IQuoteService
    {
        List<Entities.Quote> GetAll();
        Task<Entities.Quote> GetByIdAsync(int id);

        void Delete(int id);
        Task<bool> CreateAsync(Entities.Quote quote);
        bool Update(Entities.Quote quote);

    }
}
