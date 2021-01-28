using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IOtherDetails
    {
        //Screen 2 Education Qualification
        bool SaveChanges();
        IEnumerable<OtherDetails> GetOtherDetails();
        OtherDetails GetOtherDetailsById(int otherDetailsId);        
        IEnumerable<OtherDetails> GetOtherDetailsByEmployeeId(int employeeId);
        void CreateOtherDetails(OtherDetails otherDetails);

        void UpdateOtherDetails(OtherDetails otherDetails);

        void DeleteOtherDetails(OtherDetails otherDetails);
    }
}