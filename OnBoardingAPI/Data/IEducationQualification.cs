using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IEducationQualification
    {
        //Screen 2 Education Qualification
        bool SaveChanges();
        IEnumerable<EducationQualification> GetEducationQualifications();
        EducationQualification GetEducationQualificationsByEducationId(int educationId);        
        IEnumerable<EducationQualification> GetEducationQualificationsByEmployeeId(int employeeId);
        void CreateEducationQualifications(EducationQualification educationQualifications);

        void UpdateEducationQualifications(EducationQualification educationQualifications);

        void DeleteEducationQualifications(EducationQualification educationQualifications);
    }
}