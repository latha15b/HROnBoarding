using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class OtherProfessionalDetailsProfile : Profile
    {
        public OtherProfessionalDetailsProfile()
        {   
            //Source -> Target
            CreateMap<OtherProfessionalDetails, OtherProfessionalDetailsReadDto>();
            CreateMap<OtherProfessionalDetailsCreateDto, OtherProfessionalDetails>();
            CreateMap<OtherProfessionalDetailsCreateDto, OtherProfessionalDetailsReadDto>();
            CreateMap<OtherProfessionalDetailsUpdateDto, OtherProfessionalDetails>();
            CreateMap<OtherProfessionalDetails, OtherProfessionalDetailsUpdateDto>();
            CreateMap<RatingLevel, RatingLevelReadDto>();
        }
    }

}