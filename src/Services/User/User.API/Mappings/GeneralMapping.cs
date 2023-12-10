using AutoMapper;
using User.API.Dtos;

namespace User.API.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Entities.User, RegisterDto>().ReverseMap();
        }
    }
}
