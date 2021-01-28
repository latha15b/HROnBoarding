using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class PreviousEmployersProfile : Profile
    {
        public PreviousEmployersProfile()
        {   
            //Source -> Target
            CreateMap<PreviousEmployer, PreviousEmployersReadDto>();
            CreateMap<PreviousEmployersCreateDto, PreviousEmployer>();
            CreateMap<PreviousEmployersUpdateDto, PreviousEmployer>();
            CreateMap<PreviousEmployer, PreviousEmployersUpdateDto>();
        }
    }

}