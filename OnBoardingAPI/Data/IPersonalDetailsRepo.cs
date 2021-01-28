using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IPersonalDetailsRepo
    {
        //Screen 1 Personal Details
        bool SaveChanges();
        IEnumerable<PersonalDetails> GetAllPersonalDetails();
        
        IEnumerable<State> GetAllStateDetails();

        IEnumerable<City> GetAllCityDetails(int stateId);

        IEnumerable<City> GetAllCityDetailsByStateName(string stateName);

        PersonalDetails GetPersonalDetailsById(int employeeId);
        void CreatePersonalDetails(PersonalDetails personalDetails);

        void UpdatePersonalDetails(PersonalDetails personalDetails);

        void DeletePersonalDetails(PersonalDetails personalDetails);

        //Screen 2 Education Qualifications
        // IEnumerable<EducationQualification> GetAllEducationQualifications();

        // IEnumerable<EducationQualification> GetEducationQualificationsById(int employeeId);

        // //Screen 2 Education Certifications
        // IEnumerable<EducationCertification> GetAllEducationCertifications();

        // IEnumerable<EducationCertification> GetEducationCertificationsById(int employeeId);

        // //Screen 3 Previous Employers
        // IEnumerable<PreviousEmployer> GetAllPreviousEmployers();

        // IEnumerable<PreviousEmployer> GetPreviousEmployersById(int employeeId);

        // //Screen 4 Group Medical Cover
        // IEnumerable<GroupMedicalCover> GetAllGroupMedicalCovers();

        // GroupMedicalCover GetGroupMedicalCoverById(int employeeId);

        // //Screen 5 Other Details
        // IEnumerable<OtherDetails> GetAllOtherDetails();

        // OtherDetails GetOtherDetailsById(int employeeId);

        // //Screen 6 Other Professional Details
        // IEnumerable<OtherProfessionalDetails> GetAllOtherProfessionalDetails();

        // OtherProfessionalDetails GetOtherProfessionalDetailsById(int employeeId);
        
    }
}