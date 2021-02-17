using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Mail;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace OnBoardingAPI.Controllers
{
    //api/uploadDocuments
    [Route("api/uploadDocuments")]
    [ApiController]
    public class UploadDocumentsController : ControllerBase
    {
        private readonly IUploadDocuments _repository;
        private readonly IMapper _mapper;
        private readonly IPersonalDetailsRepo _repositoryPersonalDetails;
        private IWebHostEnvironment _hostingEnvironment;
        public UploadDocumentsController(IWebHostEnvironment hostingEnvironment,IUploadDocuments repository, IMapper mapper,IPersonalDetailsRepo repositoryPersonalDetails)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryPersonalDetails = repositoryPersonalDetails;
            _hostingEnvironment = hostingEnvironment;

        }

        //GET api/uploadDocuments
        [HttpGet]
        public ActionResult <IEnumerable<UploadDocumentsReadDto>> GetAllUploadDocuments()
        {
            var uploadDocumentItems =  _repository.GetUploadDocuments();

            return Ok(_mapper.Map<IEnumerable<UploadDocumentsReadDto>>(uploadDocumentItems));
        }

        //GET api/uploadDocuments/{id}
        [HttpGet("{id}", Name="GetUploadDocumentsByEmployeeId")]
        public ActionResult <IEnumerable<UploadDocumentsReadDto>> GetUploadDocumentsByEmployeeId(int id)
        {
            var uploadDocumentItems = _repository.GetUploadDocumentsByEmployeeId(id);

            if(uploadDocumentItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<UploadDocumentsReadDto>>(uploadDocumentItems));
            }

            return NotFound();
        }

        //GET api/uploadDocuments/GetAllDocumentType
        [HttpGet]
        [Route("GetAllDocumentType")]        
        public ActionResult <IEnumerable<DocumentTypeReadDto>> GetAllDocumentType()
        {
            var documentTypes = _repository.GetAllDocumentType();

            return Ok(_mapper.Map<IEnumerable<DocumentTypeReadDto>>(documentTypes));
        }

        //POST api/uploadDocuments
        [HttpPost]
        public ActionResult <IEnumerable<UploadDocumentsReadDto>> UploadDocument()
        {
            if(Request.Form.Files[0] !=  null)
            {
                Byte[] fileContent = null;
                 UploadDocumentsCreateDto uploadDocumentsCreate = new UploadDocumentsCreateDto();
                using (var memoryStream = new MemoryStream())
                {
                    Request.Form.Files[0].OpenReadStream().CopyTo(memoryStream);
                    fileContent =  memoryStream.ToArray();
                    uploadDocumentsCreate.FileContent = fileContent;
                }

                List<int> listValues = new List<int>();
                foreach (string key in Request.Form.Keys)
                {
                    if (key.Contains("DocumentTypeId"))
                    {
                        listValues.Add(Convert.ToInt32(Request.Form[key]));
                        uploadDocumentsCreate.DocumentTypeId = Convert.ToInt32(Request.Form[key]);
                    }
                    if (key.Contains("PersonalDetailEmployeeId"))
                    {
                        listValues.Add(Convert.ToInt32(Request.Form[key]));
                        uploadDocumentsCreate.PersonalDetailEmployeeId = Convert.ToInt32(Request.Form[key]);
                    }
                }
                
               
                uploadDocumentsCreate.ModifiedDate = DateTime.Now;
                uploadDocumentsCreate.FileName = Request.Form.Files[0].FileName;
                var uploadDocumentsModel = _mapper.Map<UploadDocuments>(uploadDocumentsCreate);
                _repository.CreateUploadDocuments(uploadDocumentsModel);
                _repository.SaveChanges();
                
                var uploadDocumentList = _repository.GetUploadDocumentsByEmployeeId(uploadDocumentsCreate.PersonalDetailEmployeeId);

                 //var uploadDocumentsReadDto = _mapper.Map<UploadDocumentsReadDto>(uploadDocumentsModel);
                 //int uploadDocumentsId = uploadDocumentsReadDto.UploadDocumentId;

                return Ok(_mapper.Map<IEnumerable<UploadDocumentsReadDto>>(uploadDocumentList));
                // CreatedAtRoute(nameof(GetUploadDocumentsByEmployeeId), 
                //new {Id = uploadDocumentsCreate.PersonalDetailEmployeeId}, uploadDocumentsReadDto);

            }
            else
            {
                return NoContent();
            }
                // var file = Request.Form.Files[0];
                // var doc = Request.Form.Keys;
                // string fileName = string.Empty;
                // string folderName = "Upload";
                // string webRootPath = _hostingEnvironment.ContentRootPath ;
                // string newPath = Path.Combine(webRootPath, folderName);
                // if (!Directory.Exists(newPath))
                // {
                //     Directory.CreateDirectory(newPath);
                // }
                // if (file.Length > 0)
                // {
                //     fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                //     string fullPath = Path.Combine(newPath, fileName);
                //     using (var stream = new FileStream(fullPath, FileMode.Create))
                //     {
                //         file.CopyTo(stream);
                //     }
                // }

                //Byte[] fileContent = null;
               

                
            

        }

        //POST api/uploadDocuments/{id}
        [HttpPost("{id}", Name="SubmitUploadDocuments")]
        public ActionResult <IEnumerable<UploadDocumentsReadDto>> SubmitUploadDocuments(int id)
        {
       
            PersonalDetails personalDetails = _repositoryPersonalDetails.GetPersonalDetailsById(id);
                if(personalDetails == null)
                {
                    return NotFound();
                }
                else
                {
                var employeeName = string.Concat(personalDetails.Title," ",personalDetails.FirstName," ",personalDetails.LastName);
                SendEmail("latha.15b@gmail.com","latha.15b@gmail.com",employeeName);
                var uploadDocumentList = _repository.GetUploadDocumentsByEmployeeId(id);
                return Ok(_mapper.Map<IEnumerable<UploadDocumentsReadDto>>(uploadDocumentList));
            
                }

        }

        //PUT api/uploadDocuments/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUploadDocuments(int id, IEnumerable<UploadDocumentsUpdateDto> uploadDocumentsUpdateDto)
        {
            foreach(var uploadDocumentsUpdate in uploadDocumentsUpdateDto)
            {
                UploadDocuments previousEmployerModelFromRepo = 
                        _repository.GetUploadDocumentsById(uploadDocumentsUpdate.UploadDocumentId);

                if(previousEmployerModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(uploadDocumentsUpdate, previousEmployerModelFromRepo);

                _repository.UpdateUploadDocuments(previousEmployerModelFromRepo);

                _repository.SaveChanges();
            }
            return NoContent();
        }

        //PATCH api/uploadDocuments/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<UploadDocumentsUpdateDto> patchDocument)
        {
            var previousEmployerModelFromRepo = _repository.GetUploadDocumentsById(id);

            if(previousEmployerModelFromRepo == null)
            {
                return NotFound();
            }

            var uploadDocumentsToPatch = _mapper.Map<UploadDocumentsUpdateDto>(previousEmployerModelFromRepo);

            patchDocument.ApplyTo(uploadDocumentsToPatch, ModelState);

            if(!TryValidateModel(uploadDocumentsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(uploadDocumentsToPatch, previousEmployerModelFromRepo);

            _repository.UpdateUploadDocuments(previousEmployerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/uploadDocuments/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUploadDocuments(int id)
        {
             var uploadDocumentsModelFromRepo = _repository.GetUploadDocumentsById(id);

            if(uploadDocumentsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteUploadDocuments(uploadDocumentsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        private void SendEmail(string toAddress,string passCode,string employeeName)
        {
            
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("latha.basavaraju@cai.io", "******");
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("latha.15b@gmail.com", "******");

                client.EnableSsl = true;
                client.Credentials = credentials;

                //MailMessage message = new MailMessage("latha.basavaraju@cai.io", toAddress);
                MailMessage message = new MailMessage("latha.15b@gmail.com", toAddress);
                message.Subject = "Submission of OnBoarding :" + employeeName;
                message.IsBodyHtml = true;
                message.Body = "<b style='font-size: 15pt' size = 50> Hi </b>,<br> <br>" + "<b style='font-size: 15pt' size = 50 >  The OnBoarding Process is Complete for the Employee " + employeeName +"  </b>" + "<br> <br> <em font size=7 style= 'color: DarkBlue'> Thanks </em>";
                client.Send(message);
        } 


    }
}
