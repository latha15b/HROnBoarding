using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class Kid
    {
        [Key]
        public int KidId { get; set; }

        [Required]
        [MaxLength(250)]
        public string KidName { get; set; }

        [Required]
        public string KidGender { get; set; }

        [Required]
        public DateTime KidDateOfBirth { get; set; }
        
        public int GroupMedicalCoverGroupMedicalId { get; set; }
        
        public GroupMedicalCover GroupMedicalCover { get; set; }
        
    }
}