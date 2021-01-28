using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtherProfessionalDetailsCreateDto
    {

        public string PrimarySkills { get; set; }

        public int PrimarySkillsLevel { get; set; }

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

        public int PersonalDetailEmployeeId { get; set; }

        public IEnumerable<PersonalDetails> PersonalDetails { get; set; }
        
    }
}