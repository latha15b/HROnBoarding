using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class GroupMedicalCoversProfile : Profile
    {
        public GroupMedicalCoversProfile()
        {   
            //Source -> Target
            CreateMap<GroupMedicalCover, GroupMedicalCoversReadDto>();
            CreateMap<GroupMedicalCoversCreateDto, GroupMedicalCover>();
            CreateMap<GroupMedicalCoversCreateDto, GroupMedicalCoversReadDto>();
            CreateMap<GroupMedicalCoversUpdateDto, GroupMedicalCover>();
            CreateMap<GroupMedicalCover, GroupMedicalCoversUpdateDto>();
        }
    }

}