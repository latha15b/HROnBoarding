using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class KidsProfile : Profile
    {
        public KidsProfile()
        {   
            //Source -> Target
            CreateMap<Kid, KidsReadDto>();
            CreateMap<KidsCreateDto, Kid>();
            CreateMap<KidsCreateDto, KidsReadDto>();
            CreateMap<KidsUpdateDto, Kid>();
            CreateMap<Kid, KidsUpdateDto>();
        }
    }

}