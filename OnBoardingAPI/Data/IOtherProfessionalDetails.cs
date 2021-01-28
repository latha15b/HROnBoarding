using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IOtherProfessionalDetails
    {
        //Screen 2 Education Qualification
        bool SaveChanges();
        IEnumerable<OtherProfessionalDetails> GetOtherProfessionalDetails();
        OtherProfessionalDetails GetOtherProfessionalDetailsById(int otherProfessionalDetailsId);        
        IEnumerable<OtherProfessionalDetails> GetOtherProfessionalDetailsByEmployeeId(int employeeId);
        IEnumerable<RatingLevel> GetAllRatingLevelDetails();
        void CreateOtherProfessionalDetails(OtherProfessionalDetails otherProfessionalDetails);

        void UpdateOtherProfessionalDetails(OtherProfessionalDetails otherProfessionalDetails);

        void DeleteOtherProfessionalDetails(OtherProfessionalDetails otherProfessionalDetails);
    }
}