using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class KidsCreateDto
    {
   
        [Required]
        [MaxLength(250)]
        public string KidName { get; set; }

        [Required]
        public string KidGender { get; set; }

        [Required]
        public DateTime KidDateOfBirth { get; set; }

        public int GroupMedicalCoverGroupMedicalId { get; set; }
        
    }
}