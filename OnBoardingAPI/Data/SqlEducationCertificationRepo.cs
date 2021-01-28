using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlEducationCertificationRepo : IEducationCertification
    {
        private readonly OnBoardingContext _context;
        public SqlEducationCertificationRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreateEducationCertifications(
            EducationCertification educationCertifications)
        {
            if(educationCertifications == null)
            {
                throw new ArgumentNullException(nameof(educationCertifications));
            }

            
            // foreach(EducationCertification edu in educationCertifications)
            // {
                _context.EducationCertifications.Add(educationCertifications);        
            //}
        }

        public void DeleteEducationCertifications(EducationCertification educationCertifications)
        {
            if(educationCertifications == null)
            {
                throw new ArgumentNullException(nameof(educationCertifications));
            }

            _context.EducationCertifications.Remove(educationCertifications);        
        }

        public IEnumerable<EducationCertification> GetEducationCertifications()
        {
            var test = _context.EducationCertifications.ToList();

            return _context.EducationCertifications.ToList();
        }

        public IEnumerable<EducationCertification> GetEducationCertificationsByEmployeeId(int employeeId)
        {
            return _context.EducationCertifications.Where(eduCer => 
            eduCer.PersonalDetailEmployeeId == employeeId).ToList();
        }

        public EducationCertification GetEducationCertificationsByCertificateId(int certificateId)
        {
            return _context.EducationCertifications.FirstOrDefault(eduCer => 
            eduCer.EducationCertificationId == certificateId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateEducationCertifications(EducationCertification educationCertifications)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
    }
}