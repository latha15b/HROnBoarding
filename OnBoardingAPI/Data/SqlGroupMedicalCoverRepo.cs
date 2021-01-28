using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;
using OnBoardingAPI.Dtos;

namespace OnBoardingAPI.Data
{
    public class SqlGroupMedicalCoverRepo : IGroupMedicalCover
    {
        private readonly OnBoardingContext _context;
        public SqlGroupMedicalCoverRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreateGroupMedicalCovers(
            GroupMedicalCover groupMedicalCovers)
        {
            if(groupMedicalCovers == null)
            {
                throw new ArgumentNullException(nameof(groupMedicalCovers));
            }

            
            // foreach(GroupMedicalCover grp in groupMedicalCovers)
            // {
                _context.GroupMedicalCovers.Add(groupMedicalCovers); 
            // }

        }

        public void DeleteGroupMedicalCovers(GroupMedicalCover GroupMedicalCovers)
        {
            if(GroupMedicalCovers == null)
            {
                throw new ArgumentNullException(nameof(GroupMedicalCovers));
            }

            _context.GroupMedicalCovers.Remove(GroupMedicalCovers);        
        }

        public IEnumerable<GroupMedicalCover> GetGroupMedicalCovers()
        {
            var test = _context.GroupMedicalCovers.ToList();

            return _context.GroupMedicalCovers.ToList();
        }

        public GroupMedicalCover GetGroupMedicalCoversByGroupMedicalId(int groupMedicalId)
        {
            return _context.GroupMedicalCovers.Where(grp => 
            grp.GroupMedicalId == groupMedicalId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateGroupMedicalCovers(GroupMedicalCover GroupMedicalCovers)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetailsUpdateDto personalDetails)
        {
        }
    }
}