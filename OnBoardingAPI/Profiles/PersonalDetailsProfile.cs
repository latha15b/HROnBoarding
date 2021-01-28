using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class PersonalDetailsProfile : Profile
    {
        public PersonalDetailsProfile()
        {   
            //Source -> Target
            CreateMap<PersonalDetails, PersonalDetailsReadDto>();
            CreateMap<PersonalDetailsCreateDto, PersonalDetails>();
            CreateMap<PersonalDetailsUpdateDto, PersonalDetails>();
            CreateMap<PersonalDetails, PersonalDetailsUpdateDto>();
            CreateMap<State, StateReadDto>();
            CreateMap<City, CityReadDto>();
        }
    }

}