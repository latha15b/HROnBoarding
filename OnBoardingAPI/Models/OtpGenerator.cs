using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtpGenerator
    {
        [Key]
        public int OtpId { get; set; }

        [Required]
        public string CellNumber { get; set; }
        
        public string OtpCode { get; set; }

        public DateTime TimeoutTime { get; set; }
        
        [Required]
        public string EmailId { get; set; }

    }
}