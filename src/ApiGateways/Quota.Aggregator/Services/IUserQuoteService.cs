using Quota.Aggregator.Dtos;

namespace Quota.Aggregator.Services
{
    public interface IUserQuoteService
    {
        Task<QuoteDto> GetQuoteAsync(int id);
    }
}
