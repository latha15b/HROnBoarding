using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class OtherDetailsProfile : Profile
    {
        public OtherDetailsProfile()
        {   
            //Source -> Target
            CreateMap<OtherDetails, OtherDetailsReadDto>();
            CreateMap<OtherDetailsCreateDto, OtherDetails>();
            CreateMap<OtherDetailsCreateDto, OtherDetailsReadDto>();
            CreateMap<OtherDetailsUpdateDto, OtherDetails>();
            CreateMap<OtherDetails, OtherDetailsUpdateDto>();
        }
    }

}