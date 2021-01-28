using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtpGeneratorsCreateDto
    {
       
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