using System;
using System.Collections.Generic;
using System.Linq;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Data
{
    public class SqlUploadDocumentsRepo : IUploadDocuments
    {
        private readonly OnBoardingContext _context;
        public SqlUploadDocumentsRepo(OnBoardingContext context)
        {
            _context = context;
        }


        public void CreateUploadDocuments(
            UploadDocuments uploadDocuments)
        {
            if(uploadDocuments == null)
            {
                throw new ArgumentNullException(nameof(uploadDocuments));
            }

            //foreach(UploadDocuments edu in uploadDocuments)
            //{
               _context.UploadDocuments.Add(uploadDocuments);        
            //}
        }

        public void SubmitUploadDocuments(int employeeId)
        {

        }
        public void DeleteUploadDocuments(UploadDocuments uploadDocuments)
        {
            if(uploadDocuments == null)
            {
                throw new ArgumentNullException(nameof(uploadDocuments));
            }

            _context.UploadDocuments.Remove(uploadDocuments);        
        }

        public IEnumerable<UploadDocuments> GetUploadDocuments()
        {
            var test = _context.UploadDocuments.ToList();

            return _context.UploadDocuments.ToList();
        }

        public IEnumerable<UploadDocuments> GetUploadDocumentsByEmployeeId(int employeeId)
        {
            
             var res = _context.UploadDocuments.Where(doc => 
            doc.PersonalDetailEmployeeId == employeeId).ToList();
            return _context.UploadDocuments.Where(doc => 
            doc.PersonalDetailEmployeeId == employeeId).ToList();

        }

        public IEnumerable<DocumentType> GetAllDocumentType()
        {
            return _context.DocumentType.ToList().OrderBy(doc => doc.DocumentTypeName);
        }
        
        public UploadDocuments GetUploadDocumentsById(int uploadDocumentsId)
        {
            return _context.UploadDocuments.FirstOrDefault(doc => 
            doc.UploadDocumentId == uploadDocumentsId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }

        public void UpdateUploadDocuments(UploadDocuments uploadDocuments)
        {
            //Nothing
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            //Nothing
        }
        public void UploadDocuments()
        {
            //Nothing
        }
    }
}