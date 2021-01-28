using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtpGeneratorsReadDto
    {
        public int OtpId { get; set; }
       
        public string CellNumber { get; set; }

        public string OtpCode { get; set; }
        public DateTime TimeoutTime { get; set; }
        public string EmailId { get; set; }
        
    }
}