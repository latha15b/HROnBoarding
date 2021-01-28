using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlPreviousEmployerRepo : IPreviousEmployer
    {
        private readonly OnBoardingContext _context;
        public SqlPreviousEmployerRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreatePreviousEmployers(
            PreviousEmployer PreviousEmployers)
        {
            if(PreviousEmployers == null)
            {
                throw new ArgumentNullException(nameof(PreviousEmployers));
            }

            
            // foreach(PreviousEmployer preEmp in PreviousEmployers)
            // {
                    _context.PreviousEmployers.Add(PreviousEmployers);        
            // }
        }

        public void DeletePreviousEmployers(PreviousEmployer PreviousEmployers)
        {
            if(PreviousEmployers == null)
            {
                throw new ArgumentNullException(nameof(PreviousEmployers));
            }

            _context.PreviousEmployers.Remove(PreviousEmployers);        
        }

        public IEnumerable<PreviousEmployer> GetPreviousEmployers()
        {
            var test = _context.PreviousEmployers.ToList();

            return _context.PreviousEmployers.ToList();
        }

        public IEnumerable<PreviousEmployer> GetPreviousEmployersByEmployeeId(int employeeId)
        {
            return _context.PreviousEmployers.Where(preEmp => 
            preEmp.PersonalDetailEmployeeId == employeeId).ToList();
        }

        public PreviousEmployer GetPreviousEmployersByPreviousEmployerId(int previousEmployerId)
        {
            return _context.PreviousEmployers.FirstOrDefault(preEmp => 
            preEmp.PreviousEmployerId == previousEmployerId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdatePreviousEmployers(PreviousEmployer PreviousEmployers)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
    }
}