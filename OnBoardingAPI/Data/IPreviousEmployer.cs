using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IPreviousEmployer
    {
        //Screen 4 Previous Employer
        bool SaveChanges();
        IEnumerable<PreviousEmployer> GetPreviousEmployers();
        PreviousEmployer GetPreviousEmployersByPreviousEmployerId(int previousEmployerId);        
        IEnumerable<PreviousEmployer> GetPreviousEmployersByEmployeeId(int employeeId);
        void CreatePreviousEmployers(PreviousEmployer previousEmployers);

        void UpdatePreviousEmployers(PreviousEmployer previousEmployers);
       
        void DeletePreviousEmployers(PreviousEmployer previousEmployers);
    }
}