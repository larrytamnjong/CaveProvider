using AutoMapper;
using CaveProvider.Identity.API.Dto;
using CaveProvider.Identity.API.Models;

namespace CaveProvider.Identity.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        }
    }
}
