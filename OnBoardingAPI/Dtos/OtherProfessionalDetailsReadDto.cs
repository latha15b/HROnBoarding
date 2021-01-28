using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtherProfessionalDetailsReadDto
    {
        [Key]
        public int OtherProfessionalDetailsId { get; set; }

        public string PrimarySkills { get; set; }

        public int PrimarySkillsLevel { get; set; }

        public string SecondarySkills { get; set; }

        public int SecondarySkillLevel { get; set; }

        public int VerbalCommunicationLevel { get; set; }

        public int WrittenCommunicationLevel { get; set; }

        public int PresentationSkillsLevel { get; set; }

        public int CustomerInterfactingLevel { get; set; }

        public IEnumerable<PersonalDetails> PersonalDetails { get; set; }
        
    }
}