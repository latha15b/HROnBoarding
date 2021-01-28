using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;
using System.Net;
using System.Net.Mail;
using System;

namespace OnBoardingAPI.Controllers
{
    //api/otpGenerators
    [Route("api/otpGenerators")]
    [ApiController]
    public class OtpGeneratorsController : ControllerBase
    {
        private readonly IOtpGenerator _repository;
        private readonly IMapper _mapper;

        public OtpGeneratorsController(IOtpGenerator repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/otpGenerators
        [HttpGet]
        public ActionResult <IEnumerable<OtpGeneratorsReadDto>> GetAllOtpGenerators()
        {
            var OtpGeneratorItems =  _repository.GetOtpGenerators();
            return Ok(_mapper.Map<IEnumerable<OtpGeneratorsReadDto>>(OtpGeneratorItems));
        }
      
        public ActionResult <IEnumerable<OtpGeneratorsReadDto>> GetOtpGeneratorsByOtpCode(int id)
        {
            var OtpGeneratorItems = _repository.GetOtpGeneratorsByOtpCode(id.ToString());

            if(OtpGeneratorItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<OtpGeneratorsReadDto>>(OtpGeneratorItems));
            }

            return NotFound();
        }

         public ActionResult <IEnumerable<OtpGeneratorsReadDto>> GetOtpGeneratorsByOtpGeneratorId(int id)
        {
            var OtpGeneratorItems = _repository.GetOtpGeneratorsByOtpGeneratorId(id);

            if(OtpGeneratorItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<OtpGeneratorsReadDto>>(OtpGeneratorItems));
            }

            return NotFound();
        }

        //GET api/otpGenerators/{id}
        [HttpGet("{id}")]       
        public bool ValidateOtpTimeOutTime(int id)
        {
            var OtpGeneratorItems =  _repository.GetOtpGeneratorsByOtpCode(id.ToString());
            if(OtpGeneratorItems!=null)
            {
                if(OtpGeneratorItems.TimeoutTime >= DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }   
        //POST api/otpGenerators/{id}
        [HttpPost("{id}")]
        public bool ValidateOtpCode(int id)
        {
            var OtpGeneratorItems =  _repository.GetOtpGeneratorsByOtpCode(id.ToString());
            if(OtpGeneratorItems !=null)
            {
                return true;
            } 
            else
            {
                return false;
            }

        }   

        //POST api/otpGenerators
        [HttpPost]
        public ActionResult <IEnumerable<OtpGeneratorsReadDto>> CreateOtpGenerators(OtpGeneratorsCreateDto OtpGeneratorsCreateDto) 
        {
            
            var otpGeneratorsModel = _mapper.Map<OtpGenerator>(OtpGeneratorsCreateDto);
            otpGeneratorsModel.TimeoutTime=DateTime.Now.AddMinutes(30);
            _repository.CreateOtpGenerators(otpGeneratorsModel);
            _repository.SaveChanges();

            var OtpGeneratorsReadDto = _mapper.Map<OtpGeneratorsReadDto>(otpGeneratorsModel);

            SendEmail(otpGeneratorsModel.EmailId,otpGeneratorsModel.OtpCode.ToString());
            
            return Ok(_mapper.Map<OtpGeneratorsReadDto>(OtpGeneratorsReadDto));
            
        }

        //PUT api/otpGenerators/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOtpGenerator(int id, 
                                            OtpGeneratorsUpdateDto otpGeneratorsUpdateDto)
        {
            var otpGeneratorsModelFromRepo = _repository.GetOtpGeneratorsByOtpGeneratorId(id);

            if(otpGeneratorsModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(otpGeneratorsUpdateDto, otpGeneratorsModelFromRepo);

            _repository.UpdateOtpGenerators(otpGeneratorsModelFromRepo);

            _repository.SaveChanges();

            SendEmail(otpGeneratorsUpdateDto.EmailId,otpGeneratorsUpdateDto.OtpCode);

            return NoContent();
            
        }

        //PATCH api/otpGenerators/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<OtpGeneratorsUpdateDto> patchDocument)
        {
            var otpGeneratorModelFromRepo = _repository.GetOtpGeneratorsByOtpGeneratorId(id);

            if(otpGeneratorModelFromRepo == null)
            {
                return NotFound();
            }

            var otpGeneratorsToPatch = _mapper.Map<OtpGeneratorsUpdateDto>(otpGeneratorModelFromRepo);

            patchDocument.ApplyTo(otpGeneratorsToPatch, ModelState);

            if(!TryValidateModel(otpGeneratorsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(otpGeneratorsToPatch, otpGeneratorModelFromRepo);

            _repository.UpdateOtpGenerators(otpGeneratorModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/otpGenerators/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOtpGenerators(int id)
        {
             var otpGeneratorsModelFromRepo = _repository.GetOtpGeneratorsByOtpGeneratorId(id);

            if(otpGeneratorsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteOtpGenerators(otpGeneratorsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        private void SendEmail(string toAddress,string passCode)
        {
            
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("latha.basavaraju@cai.io", "GANesh!%^0");
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("latha.15b@gmail.com", "T@lent15");

                client.EnableSsl = true;
                client.Credentials = credentials;

                //MailMessage message = new MailMessage("latha.basavaraju@cai.io", toAddress);
                MailMessage message = new MailMessage("latha.15b@gmail.com", toAddress);
                message.Subject = "Welcome To CAI";
                message.IsBodyHtml = true;
                message.Body = "<b style='font-size: 15pt' size = 50> Hi </b>,<br> <br>" + "<b style='font-size: 15pt' size = 50 > Welcome To Computer Aid !!!!  </b>" + "<br> <br> <em font size=7 style= 'color: DarkBlue'> We are pleased to share your Login Information. Please use the below Passcode for Login.<br> PassCode :" + passCode + "</em>";
                client.Send(message);
        } 

       

    }
}