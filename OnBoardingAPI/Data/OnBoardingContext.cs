using Microsoft.EntityFrameworkCore;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class OnBoardingContext : DbContext
    {

        public OnBoardingContext(DbContextOptions<OnBoardingContext> opt) : base(opt)
        {
            
        }
        public DbSet<OtpGenerator> OtpGenerator { get; set; }

        public DbSet<PersonalDetails> PersonalDetails { get; set; }    

        public DbSet<EducationQualification> EducationQualifications { get; set; }

        public DbSet<EducationCertification> EducationCertifications { get; set; }

        public DbSet<PreviousEmployer> PreviousEmployers { get; set; }

        public DbSet<Kid> Kids { get; set; }

        public DbSet<GroupMedicalCover> GroupMedicalCovers { get; set; }

        public DbSet<OtherDetails> OtherDetails { get; set; }

        public DbSet<OtherProfessionalDetails> OtherProfessionalDetails { get; set; }

        public DbSet<UploadDocuments> UploadDocuments { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<City> City { get; set; }
        
        public DbSet<RatingLevel> RatingLevel { get; set; }
        
        public DbSet<DocumentType> DocumentType { get; set; }
        
        

    }

}