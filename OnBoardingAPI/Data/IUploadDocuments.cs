using System.Collections.Generic;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public interface IUploadDocuments
    {
        //Screen 2 Education Qualification
        bool SaveChanges();
        IEnumerable<UploadDocuments> GetUploadDocuments();
        UploadDocuments GetUploadDocumentsById(int uploadDocumentsId);        
        IEnumerable<UploadDocuments> GetUploadDocumentsByEmployeeId(int employeeId);      
        IEnumerable<DocumentType> GetAllDocumentType();
        void CreateUploadDocuments(UploadDocuments uploadDocuments);
        void SubmitUploadDocuments(int employeeId);

        void UploadDocuments();
        void UpdateUploadDocuments(UploadDocuments uploadDocuments);

        void DeleteUploadDocuments(UploadDocuments uploadDocuments);
    }
}