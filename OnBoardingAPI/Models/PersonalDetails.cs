using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnBoardingAPI.Models
{
    public class PersonalDetails
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string CellNumber { get; set; }

        [Required]
        [MaxLength(1000)]
        public string CurrentAddress { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int Pincode { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(10)]
        public string BloodGroup { get; set; }

        [Required]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string PersonalEmailId { get; set; }

        public bool IsDeclarationStatus { get; set; }

        [Required]
        public int TotalYearsOfExperience { get; set; }

        public int? GroupMedicalCoverGroupMedicalId { get; set; }

        public int? OtherDetailsId { get; set; }

        public int? OtherProfessionalDetailsId { get; set; }

        public List<EducationQualification> EducationQualifications { get; set;}

        public List<EducationCertification> EducationCertifications { get; set;}

        public List<PreviousEmployer> PreviousEmployers { get; set; }

        public GroupMedicalCover GroupMedicalCover { get; set; }


        public OtherDetails OtherDetails { get; set; }

        public OtherProfessionalDetails OtherProfessionalDetails { get; set; }

        public UploadDocuments UploadDocuments { get; set; }

        public State State { get; set; }

        public City City { get; set; }    

        public OtpGenerator OtpGenerator { get; set; }    
    }
}