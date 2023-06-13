using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models.Entities;

namespace WebApplication1.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            //MyOpject
            CreateMap<CreateMyOpjectDto,MyOpject>().ReverseMap(); 
            CreateMap<UpdateMyOpjectDto, MyOpject>().ReverseMap();


        }
    }
}
