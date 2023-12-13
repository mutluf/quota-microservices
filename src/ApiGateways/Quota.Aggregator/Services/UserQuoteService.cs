using Microsoft.EntityFrameworkCore;
using Quota.Aggregator.Context;
using Quota.Aggregator.Dtos;
using Quota.Aggregator.Models;
using System.Text.Json.Nodes;

namespace Quota.Aggregator.Services
{
    public class UserQuoteService : IUserQuoteService
    {
        private readonly AggregatorDbContext _context;
        private readonly HttpClient _httpClient;

        public UserQuoteService(AggregatorDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public DbSet<UserQuote> Table => _context.Set<UserQuote>();


        public async Task AddAsync(string username, int quoteId)
        {
            UserQuote data = new()
            {
                Username = username,
                QuoteId = quoteId
            };

            await _context.AddAsync(data);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


        //var json = await response.Content.ReadAsStringAsync();
        //var result = string.IsNullOrEmpty(json) ? null : JsonObject.Parse(json);
        public async Task<QuoteDto> GetQuoteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/quotes/{id}");
            
            QuoteDto quote = await response.Content.ReadFromJsonAsync<QuoteDto>();

            return quote;
        }

        //public async Task<List<QuoteDto>> GetUserQuotes(string userId)
        //{
        //    var response = await _httpClient.GetAsync($"https://localhost:5005/api/users/{userId}");

        //    var quotes = await response.Content.ReadFromJsonAsync<List<QuoteDto>>();

        //    return quotes;
        //}


        //private List<string> GetUserIds(string courseId)
        //{
        //    var userIds = _context.CourseUsers.Where(c => c.CourseId == courseId).Select(u => u.UserId).ToList();
        //    return userIds;
        //}

    }
}
