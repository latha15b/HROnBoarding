using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IOtpGenerator
    {
        //Screen 6 OtpGenerator
        bool SaveChanges();

        IEnumerable<OtpGenerator> GetOtpGenerators();

        OtpGenerator GetOtpGeneratorsByOtpGeneratorId(int otpGeneratorId);        

        OtpGenerator GetOtpGeneratorsByOtpCode(string otpCode);
        
        OtpGenerator GetOtpGeneratorsByEmailId(string emailId);

        void CreateOtpGenerators(OtpGenerator otpGenerators);

        void UpdateOtpGenerators(OtpGenerator otpGenerator);

        void DeleteOtpGenerators(OtpGenerator otpGenerator);
    }
}