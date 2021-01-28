using System.Collections.Generic;
using AutoMapper;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Profiles
{
    public class UploadDocumentsProfile : Profile
    {
        public UploadDocumentsProfile()
        {   
            //Source -> Target
            CreateMap<UploadDocuments, UploadDocumentsReadDto>();
            CreateMap<UploadDocumentsCreateDto, UploadDocuments>();
            CreateMap<UploadDocumentsCreateDto, UploadDocumentsReadDto>();
            CreateMap<UploadDocumentsUpdateDto, UploadDocuments>();
            CreateMap<UploadDocuments, UploadDocumentsUpdateDto>();
            CreateMap<DocumentType, DocumentTypeReadDto>();
        }
    }

}