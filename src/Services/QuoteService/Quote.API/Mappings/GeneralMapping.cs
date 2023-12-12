using AutoMapper;
using Quote.API.Dtos;

namespace Quote.API.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<QuoteDto, Entities.Quote>().ReverseMap();
        }       
    }
}
