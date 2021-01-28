using System;

namespace OnBoardingAPI.Dtos
{
    public class DocumentTypeReadDto
    {
        public int DocumentTypeId { get; set; }

        public string DocumentTypeName { get; set; }
        
        public bool IsMandatory { get; set; }

    }
}