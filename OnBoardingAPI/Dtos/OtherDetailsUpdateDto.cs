using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class OtherDetailsUpdateDto
    {
        [Key]
        public int OtherDetailsId { get; set; }

        public string PANNumber { get; set; }

        public string NameAsOnPANCard { get; set; }

        [Required]
        [MaxLength(50)]
        public string AadhaarNumber { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameAsOnAadhaar { get; set; }

        public string PassportNumber { get; set; }

        public string NameAsOnPassport { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }

        public string PlaceOfIssue { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public string BankName {get; set;}

        public string AccountNumber { get; set; }

        public string IFSCCode { get; set; }

        public string NameAsInBankAccount { get; set; }

        public string Branch { get; set; }

        [Required]  
        [MaxLength(1000)]
        public string PermanentAddress { get; set; }

        [Required]
        [MaxLength(250)]
        public string State { get; set; }

        [Required]
        public int Pincode { get; set; }

        public IEnumerable<PersonalDetails> PersonalDetails { get; set; }
 
        
    }
}