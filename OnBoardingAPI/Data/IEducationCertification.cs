using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IEducationCertification
    {
        //Screen 3 Education Certification
        bool SaveChanges();
        IEnumerable<EducationCertification> GetEducationCertifications();
        EducationCertification GetEducationCertificationsByCertificateId(int certificateId);        
        IEnumerable<EducationCertification> GetEducationCertificationsByEmployeeId(int employeeId);
        void CreateEducationCertifications(EducationCertification educationCertifications);

        void UpdateEducationCertifications(EducationCertification educationCertifications);

        void DeleteEducationCertifications(EducationCertification educationCertifications);
    }
}