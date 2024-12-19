using AnimalManager.Application.DTOs;
using AnimalManager.Domain.Entities;
using AutoMapper;

namespace AnimalManager.Application.Mappings
{
    public class AnimalMappingProfile : Profile
    {
        public AnimalMappingProfile()
        {
            CreateMap<Animal, AnimalDto>().ReverseMap();
        }
    }
}