using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlOtherProfessionalDetailsRepo : IOtherProfessionalDetails
    {
        private readonly OnBoardingContext _context;
        public SqlOtherProfessionalDetailsRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreateOtherProfessionalDetails(
            OtherProfessionalDetails otherProfessionalDetails)
        {
            if(otherProfessionalDetails == null)
            {
                throw new ArgumentNullException(nameof(otherProfessionalDetails));
            }

            //foreach(OtherProfessionalDetails edu in otherProfessionalDetails)
            //{
               _context.OtherProfessionalDetails.Add(otherProfessionalDetails);        
            //}
        }

        public void DeleteOtherProfessionalDetails(OtherProfessionalDetails otherProfessionalDetails)
        {
            if(otherProfessionalDetails == null)
            {
                throw new ArgumentNullException(nameof(otherProfessionalDetails));
            }

            _context.OtherProfessionalDetails.Remove(otherProfessionalDetails);        
        }

        public IEnumerable<OtherProfessionalDetails> GetOtherProfessionalDetails()
        {
            var test = _context.OtherProfessionalDetails.ToList();

            return _context.OtherProfessionalDetails.ToList();
        }

        public IEnumerable<OtherProfessionalDetails> GetOtherProfessionalDetailsByEmployeeId(int employeeId)
        {
            
            int otherId =  _context.PersonalDetails.Where(emp => 
            emp.EmployeeId == employeeId).Select(emp => emp.PersonalEmailId).FirstOrDefault().First();
            return _context.OtherProfessionalDetails.Where(emp => 
            emp.OtherProfessionalDetailsId == otherId).ToList();

        }

        public IEnumerable<RatingLevel> GetAllRatingLevelDetails()
        {
            return _context.RatingLevel.ToList().OrderBy(level => level.RatingLevelDescription);
        }
        
        public OtherProfessionalDetails GetOtherProfessionalDetailsById(int otherProfessionalDetailsId)
        {
            return _context.OtherProfessionalDetails.FirstOrDefault(emp => 
            emp.OtherProfessionalDetailsId == otherProfessionalDetailsId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateOtherProfessionalDetails(OtherProfessionalDetails otherProfessionalDetails)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
    }
}