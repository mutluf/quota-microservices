using AutoMapper;
using Quote.API.Dtos;
using Quote.API.Repositories;

namespace Quote.API.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public QuoteService(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(QuoteDto quoteDto)
        {
            Entities.Quote quote = _mapper.Map<Entities.Quote>(quoteDto);
            bool result = await _quoteRepository.CreateQuoteAsync(quote);
            await _quoteRepository.SaveAsync();

            return result;
        }

        public async void Delete(int id)
        {
            _quoteRepository.DeleteQuote(id);
            await _quoteRepository.SaveAsync();
        }

        public List<QuoteDto> GetAll()
        {
            List<Entities.Quote> quotes = _quoteRepository.GetAll();
            List<QuoteDto> datas = _mapper.Map<List<QuoteDto>>(quotes);

            return datas;
        }

        public async Task<QuoteDto> GetByIdAsync(int id)
        {
            Entities.Quote quote= await _quoteRepository.GetByIdAsync(id);
            QuoteDto data = _mapper.Map<QuoteDto>(quote);

            return data;
        }

        public bool Update(QuoteDto quote)
        {
            Entities.Quote data = _mapper.Map<Entities.Quote>(quote);
            bool result = _quoteRepository.UpdateQuote(data);

            return result;
        }
    }
}
