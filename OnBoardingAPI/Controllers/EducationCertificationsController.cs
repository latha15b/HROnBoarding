using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Controllers
{
    //api/educationCertifications
    [Route("api/educationCertifications")]
    [ApiController]
    public class EducationCertificationsController : ControllerBase
    {
        private readonly IEducationCertification _repository;
        private readonly IMapper _mapper;

        public EducationCertificationsController(IEducationCertification repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/educationCertifications
        [HttpGet]
        public ActionResult <IEnumerable<EducationCertificationsReadDto>> GetAllEducationCertifications()
        {
            var educationCertificationItems =  _repository.GetEducationCertifications();

            return Ok(_mapper.Map<IEnumerable<EducationCertificationsReadDto>>(educationCertificationItems));
        }

        //GET api/educationCertifications/{id}
        [HttpGet("{id}", Name="GetEducationCertificationsByEmployeeId")]
        public ActionResult <IEnumerable<EducationCertificationsReadDto>> GetEducationCertificationsByEmployeeId(int id)
        {
            var educationCertificationItems = _repository.GetEducationCertificationsByEmployeeId(id);

            if(educationCertificationItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<EducationCertificationsReadDto>>(educationCertificationItems));
            }

            return NotFound();
        }

        //POST api/educationCertifications
        [HttpPost]
        public ActionResult <IEnumerable<EducationCertificationsReadDto>> CreateEducationCertifications(EducationCertificationsCreateDto educationCertificationsCreateDto) 
        {
            int employeeId = 0;
            var educationCertificationsModel = _mapper.Map<EducationCertification>(educationCertificationsCreateDto);
            _repository.CreateEducationCertifications(educationCertificationsModel);
            _repository.SaveChanges();

            var educationCertificationsReadDto = _mapper.Map<EducationCertificationsReadDto>(educationCertificationsModel);

           //foreach(var data in educationCertificationsReadDto)
            //{
                employeeId = educationCertificationsReadDto.PersonalDetailEmployeeId;
              //  break;
            //}    

            return CreatedAtRoute(nameof(GetEducationCertificationsByEmployeeId), 
            new {Id = employeeId}, educationCertificationsReadDto);
        }

        //PUT api/educationCertifications/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEducationCertification(int id, 
                                            EducationCertificationsUpdateDto educationCertificationsUpdateDto)
        {
            // foreach(var educationUpdate in educationCertificationsUpdateDto)
            // {
                EducationCertification educationCertificationModelFromRepo = 
                        _repository.GetEducationCertificationsByCertificateId(educationCertificationsUpdateDto.EducationCertificationId);

                if(educationCertificationModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(educationCertificationsUpdateDto, educationCertificationModelFromRepo);

                _repository.UpdateEducationCertifications(educationCertificationModelFromRepo);

                _repository.SaveChanges();
           // }
            return NoContent();
        }

        //PATCH api/educationCertifications/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<EducationCertificationsUpdateDto> patchDocument)
        {
            var educationCertificationModelFromRepo = _repository.GetEducationCertificationsByCertificateId(id);

            if(educationCertificationModelFromRepo == null)
            {
                return NotFound();
            }

            var educationCertificationsToPatch = _mapper.Map<EducationCertificationsUpdateDto>(educationCertificationModelFromRepo);

            patchDocument.ApplyTo(educationCertificationsToPatch, ModelState);

            if(!TryValidateModel(educationCertificationsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(educationCertificationsToPatch, educationCertificationModelFromRepo);

            _repository.UpdateEducationCertifications(educationCertificationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/educationCertifications/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEducationCertifications(int id)
        {
             var educationCertificationsModelFromRepo = _repository.GetEducationCertificationsByCertificateId(id);

            if(educationCertificationsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEducationCertifications(educationCertificationsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}