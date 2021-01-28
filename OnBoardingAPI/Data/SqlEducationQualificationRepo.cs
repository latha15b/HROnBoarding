using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlEducationQualificationRepo : IEducationQualification
    {
        private readonly OnBoardingContext _context;
        public SqlEducationQualificationRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreateEducationQualifications(
            EducationQualification educationQualifications)
        {
            if(educationQualifications == null)
            {
                throw new ArgumentNullException(nameof(educationQualifications));
            }

            //foreach(EducationQualification edu in educationQualifications)
            //{
               _context.EducationQualifications.Add(educationQualifications);        
            //}
        }

        public void DeleteEducationQualifications(EducationQualification educationQualifications)
        {
            if(educationQualifications == null)
            {
                throw new ArgumentNullException(nameof(educationQualifications));
            }

            _context.EducationQualifications.Remove(educationQualifications);        
        }

        public IEnumerable<EducationQualification> GetEducationQualifications()
        {
            var test = _context.EducationQualifications.ToList();

            return _context.EducationQualifications.ToList();
        }

        public IEnumerable<EducationQualification> GetEducationQualificationsByEmployeeId(int employeeId)
        {
            return _context.EducationQualifications.Where(emp => 
            emp.PersonalDetailEmployeeId == employeeId).ToList();
        }

        public EducationQualification GetEducationQualificationsByEducationId(int educationId)
        {
            return _context.EducationQualifications.FirstOrDefault(emp => 
            emp.EducationQualificationId == educationId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateEducationQualifications(EducationQualification educationQualifications)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
    }
}