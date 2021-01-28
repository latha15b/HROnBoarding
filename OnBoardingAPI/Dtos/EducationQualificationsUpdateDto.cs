using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class EducationQualificationsUpdateDto
    {
        [Key]
        public int EducationQualificationId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Qualification { get; set;}

        [Required]
        public int YearOfPassing { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameOfUniversity { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; }

        public bool IsHighestQualification { get; set;}

        public int PersonalDetailEmployeeId { get; set; }
        
    }
}