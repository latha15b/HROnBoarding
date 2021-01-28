using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        [Required]
        public string DocumentTypeName { get; set; }
        
        public bool IsMandatory { get; set; }

    }
}