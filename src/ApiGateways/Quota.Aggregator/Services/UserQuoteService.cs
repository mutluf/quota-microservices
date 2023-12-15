using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quota.Aggregator.Context;
using Quota.Aggregator.Dtos;
using Quota.Aggregator.Models;
using Quota.Aggregator.Repositories;
using System.Text.Json.Nodes;

namespace Quota.Aggregator.Services
{
    public class UserQuoteService : IUserQuoteService
    {
        
        private readonly HttpClient _httpClient;
        private readonly IUserQuoteRepository _userQuoteRepository;
        private readonly IMapper _mapper;
        public UserQuoteService(HttpClient httpClient, IUserQuoteRepository userQuoteRepository, IMapper mapper)
        {
            _httpClient = httpClient;
            _userQuoteRepository = userQuoteRepository;
            _mapper = mapper;
        }


        public async Task<QuoteDto> GetQuoteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/quotes/{id}");
            
            QuoteDto quote = await response.Content.ReadFromJsonAsync<QuoteDto>();

            return quote;
        }


        public async Task<bool> PostQuoteAsync(UserQuoteDto quoteDto)
        {
            //add data into userquotedb          
            var data = new UserQuote()
            {
                QuoteId = quoteDto.QuoteId,
                Username= quoteDto.Username
            };
            bool result = await _userQuoteRepository.CreateQuoteAsync(data);
            await _userQuoteRepository.SaveAsync();



            return result;
        }

    }
}
