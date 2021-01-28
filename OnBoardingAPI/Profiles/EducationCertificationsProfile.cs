using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class EducationCertificationsProfile : Profile
    {
        public EducationCertificationsProfile()
        {   
            //Source -> Target
            CreateMap<EducationCertification, EducationCertificationsReadDto>();
            CreateMap<EducationCertificationsCreateDto, EducationCertification>();
            CreateMap<EducationCertificationsCreateDto, EducationCertificationsReadDto>();
            CreateMap<EducationCertificationsUpdateDto, EducationCertification>();
            CreateMap<EducationCertification, EducationCertificationsUpdateDto>();
        }
        
    }

}