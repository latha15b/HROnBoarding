using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IKid
    {
        //Screen 6 Kid
        bool SaveChanges();

        IEnumerable<Kid> GetKids();

        Kid GetKidsByKidId(int kidId);        

        IEnumerable<Kid> GetKidsByGroupMedicalCoverId(int groupMedicalCoverGroupMedicalId);

        void CreateKids(IEnumerable<Kid> Kids);

        void UpdateKids(Kid kid);

        void DeleteKids(Kid kid);
    }
}