using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class EducationQualificationsProfile : Profile
    {
        public EducationQualificationsProfile()
        {   
            //Source -> Target
            CreateMap<EducationQualification, EducationQualificationsReadDto>();
            CreateMap<EducationQualificationsCreateDto, EducationQualification>();
            CreateMap<EducationQualificationsCreateDto, EducationQualificationsReadDto>();
            CreateMap<EducationQualificationsUpdateDto, EducationQualification>();
            CreateMap<EducationQualification, EducationQualificationsUpdateDto>();
        }
    }

}