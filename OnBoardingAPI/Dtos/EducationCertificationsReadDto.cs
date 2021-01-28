using System;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class EducationCertificationsReadDto
    {
       [Key]
        public int EducationCertificationId { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameOfCertifcation { get; set;}

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(250)]
        public string CertificateNumber { get; set; }

        public DateTime ExpiryDateOfCertificate { get; set; }

        public int PersonalDetailEmployeeId { get; set; }

        public PersonalDetails PersonalDetail { get; set; }

    }
}