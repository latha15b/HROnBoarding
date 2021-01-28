using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class PreviousEmployersUpdateDto
    {
        [Key]
        public int PreviousEmployerId { get; set; }

        [Required]
        [MaxLength(250)]
        public string PreviousEmployerName { get; set; }

        [Required]
        public DateTime DateOfJoining { get; set; }

        [Required]
        public DateTime LastWorkingDay { get; set; }

        [Required]
        [MaxLength(250)]
        public string ReasonForLeaving { get; set; }

        [Required]
        public bool AreTheExitFormalitiesCompleted { get; set;}

        public string UniversalAccountNo { get; set; }

        public string ProvidentFundNo { get; set; }

        public string TypeOfPFAccount { get; set; }

        public bool IsLatestLastEmployer { get; set; }
        
        public int PersonalDetailEmployeeId { get; set; }
        
    }
}