using AutoMapper;
using Quota.Aggregator.Dtos;
using Quota.Aggregator.Models;

namespace Quota.Aggregator.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserQuoteDto, UserQuote>().ReverseMap();
        }
    }
}
