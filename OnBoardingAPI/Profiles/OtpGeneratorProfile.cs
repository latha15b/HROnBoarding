using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class OtpGeneratorProfile : Profile
    {
        public OtpGeneratorProfile()
        {   
            //Source -> Target
            CreateMap<OtpGenerator, OtpGeneratorsReadDto>();
            CreateMap<OtpGeneratorsReadDto, OtpGenerator>();
            CreateMap<OtpGeneratorsCreateDto, OtpGenerator>();
            CreateMap<OtpGeneratorsCreateDto, OtpGeneratorsReadDto>();
            CreateMap<OtpGeneratorsUpdateDto, OtpGenerator>();
            CreateMap<OtpGenerator, OtpGeneratorsUpdateDto>();
        }
    }

}