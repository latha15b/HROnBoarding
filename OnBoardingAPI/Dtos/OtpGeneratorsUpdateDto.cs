using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtpGeneratorsUpdateDto
    {
        public int OtpId { get; set; }
       
        [Required]
        public string CellNumber { get; set; }
       
        [Required]
        public string OtpCode { get; set; }

        [Required]
        public DateTime TimeoutTime { get; set; }

         [Required]
        public string EmailId { get; set; }

        
    }
}