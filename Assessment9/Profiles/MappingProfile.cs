using AutoMapper;
using Assessment9.Models;
using Assessment9.DTOs;

namespace Assessment9.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
