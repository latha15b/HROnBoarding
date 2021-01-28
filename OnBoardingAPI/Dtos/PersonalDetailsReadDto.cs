
using System;
using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Dtos
{
    public class PersonalDetailsReadDto
    {
        public int EmployeeId { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CellNumber { get; set; }
        public string CurrentAddress { get; set; }
        public string CityId { get; set; }
        public int Pincode { get; set; }
        public string StateId { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string PersonalEmailId { get; set; }
        public bool IsDeclarationStatus { get; set; }
        public int TotalYearsOfExperience { get; set; }
        
        public int? GroupMedicalCoverGroupMedicalId { get; set; }
        public int? OtherDetailsId { get; set; }

        public int? OtherProfessionalDetailsId { get; set; }

        public int? UploadDocumentId { get; set; }


        public List<EducationQualification> EducationQualifications { get; set;}

        public List<EducationCertification> EducationCertifications { get; set;}

        public List<PreviousEmployer> PreviousEmployers { get; set; }

        public GroupMedicalCover GroupMedicalCover { get; set; }

        public OtherDetails OtherDetails { get; set; }

        public OtherProfessionalDetails OtherProfessionalDetails { get; set; }

       // public UploadDocument UploadDocuments { get; set; }
        
    }
}