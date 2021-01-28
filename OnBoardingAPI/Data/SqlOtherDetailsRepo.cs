using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlOtherDetailsRepo : IOtherDetails
    {
        private readonly OnBoardingContext _context;
        public SqlOtherDetailsRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreateOtherDetails(
            OtherDetails otherDetails)
        {
            if(otherDetails == null)
            {
                throw new ArgumentNullException(nameof(otherDetails));
            }

            //foreach(OtherDetails edu in otherDetails)
            //{
               _context.OtherDetails.Add(otherDetails);        
            //}
        }

        public void DeleteOtherDetails(OtherDetails otherDetails)
        {
            if(otherDetails == null)
            {
                throw new ArgumentNullException(nameof(otherDetails));
            }

            _context.OtherDetails.Remove(otherDetails);        
        }

        public IEnumerable<OtherDetails> GetOtherDetails()
        {
            var test = _context.OtherDetails.ToList();

            return _context.OtherDetails.ToList();
        }

        public IEnumerable<OtherDetails> GetOtherDetailsByEmployeeId(int employeeId)
        {
            
            var otherId =  _context.PersonalDetails.Where(emp => 
            emp.EmployeeId == employeeId).Select(emp => emp.OtherDetailsId).FirstOrDefault();
            return _context.OtherDetails.Where(emp => 
            emp.OtherDetailsId == otherId).ToList();

        }

        public OtherDetails GetOtherDetailsById(int otherDetailsId)
        {
            return _context.OtherDetails.FirstOrDefault(emp => 
            emp.OtherDetailsId == otherDetailsId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateOtherDetails(OtherDetails otherDetails)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
    }
}