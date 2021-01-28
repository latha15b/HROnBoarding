using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlKidRepo : IKid
    {
        private readonly OnBoardingContext _context;
        public SqlKidRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreateKids(
            IEnumerable<Kid> kids)
        {
            if(kids == null)
            {
                throw new ArgumentNullException(nameof(kids));
            }

            
            foreach(Kid edu in kids)
            {
                _context.Kids.Add(edu);        
            }
        }

        public void DeleteKids(Kid kids)
        {
            if(kids == null)
            {
                throw new ArgumentNullException(nameof(kids));
            }

            _context.Kids.Remove(kids);        
        }

        public IEnumerable<Kid> GetKids()
        {
            var test = _context.Kids.ToList();

            return _context.Kids.ToList();
        }

        public IEnumerable<Kid> GetKidsByGroupMedicalCoverId(int groupMedicalCoverGroupMedicalId)
        {
            return _context.Kids.Where(kid => 
            kid.GroupMedicalCoverGroupMedicalId == groupMedicalCoverGroupMedicalId).ToList();
        }

        public Kid GetKidsByKidId(int kidId)
        {
            return _context.Kids.FirstOrDefault(kid => 
            kid.KidId == kidId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateKids(Kid kids)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
    }
}