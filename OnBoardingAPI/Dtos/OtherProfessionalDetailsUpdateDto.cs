using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtherProfessionalDetailsUpdateDto
    {
        [Key]
        public int OtherProfessionalDetailsId { get; set; }

        [Required]
        [MaxLength(250)]
        public string PrimarySkills { get; set; }

        [Required]
        public int PrimarySkillsLevel { get; set; }

        [Required]
        [MaxLength(250)]
        public string SecondarySkills { get; set; }

        [Required]
        public int SecondarySkillLevel { get; set; }

        [Required]
        public int VerbalCommunicationLevel { get; set; }

        [Required]
        public int WrittenCommunicationLevel { get; set; }

        [Required]
        public int PresentationSkillsLevel { get; set; }

        [Required]
        public int CustomerInterfactingLevel { get; set; }

        public IEnumerable<PersonalDetails> PersonalDetails { get; set; }
        
    }
}