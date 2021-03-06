using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class UploadDocumentsReadDto
    {
        [Key]
        public int UploadDocumentId { get; set; }
        
        [Required]
        public byte[] FileContent { get; set; }

        [Required]
        [MaxLength(250)]
        public string FileName {get;set;}
        
        [Required]
        public DateTime  ModifiedDate {get; set;}

        public int DocumentTypeId { get; set; }

        
        public int PersonalDetailEmployeeId { get; set; }
    }
}