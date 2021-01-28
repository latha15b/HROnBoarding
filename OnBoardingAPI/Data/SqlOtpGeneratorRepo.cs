using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlOtpGeneratorRepo : IOtpGenerator
    {
        private readonly OnBoardingContext _context;
        public SqlOtpGeneratorRepo(OnBoardingContext context)
        {
            _context = context;
        }

        public void CreateOtpGenerators(OtpGenerator OtpGenerators)
        {
            if(OtpGenerators == null)
            {
                throw new ArgumentNullException(nameof(OtpGenerators));
            }

                _context.OtpGenerator.Add(OtpGenerators);        
        }

        public void DeleteOtpGenerators(OtpGenerator OtpGenerators)
        {
            if(OtpGenerators == null)
            {
                throw new ArgumentNullException(nameof(OtpGenerators));
            }

            _context.OtpGenerator.Remove(OtpGenerators);        
        }

        public IEnumerable<OtpGenerator> GetOtpGenerators()
        {
            var test = _context.OtpGenerator.ToList();

            return _context.OtpGenerator.ToList();
        }

        public OtpGenerator GetOtpGeneratorsByOtpCode(string otpCode)
        {
            return _context.OtpGenerator.Where(OtpGenerator => 
            OtpGenerator.OtpCode== otpCode).FirstOrDefault();
        }

        public OtpGenerator GetOtpGeneratorsByOtpGeneratorId(int OtpGeneratorId)
        {
            return _context.OtpGenerator.FirstOrDefault(OtpGenerator => 
            OtpGenerator.OtpId == OtpGeneratorId);
        }
        public OtpGenerator GetOtpGeneratorsByEmailId(string emailId)
        {
             return _context.OtpGenerator.Where(OtpGenerator => 
            OtpGenerator.EmailId== emailId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateOtpGenerators(OtpGenerator OtpGenerators)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
    }
}