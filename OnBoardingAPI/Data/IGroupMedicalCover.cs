using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IGroupMedicalCover
    {
        //Screen 2 Education Qualification
        bool SaveChanges();
        IEnumerable<GroupMedicalCover> GetGroupMedicalCovers();
        GroupMedicalCover GetGroupMedicalCoversByGroupMedicalId(int groupMedicalId);       
        void CreateGroupMedicalCovers(GroupMedicalCover groupMedicalCovers);

        void UpdateGroupMedicalCovers(GroupMedicalCover groupMedicalCover);
        //void UpdatePersonalDetails(PersonalDetails personalDetails);
        void DeleteGroupMedicalCovers(GroupMedicalCover groupMedicalCover);
    }
}