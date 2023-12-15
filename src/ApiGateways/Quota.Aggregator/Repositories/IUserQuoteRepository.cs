using Quota.Aggregator.Models;

namespace Quota.Aggregator.Repositories
{
    public interface IUserQuoteRepository
    {
        Task<bool> CreateQuoteAsync(UserQuote userQuote);
        Task SaveAsync();
    }
}
