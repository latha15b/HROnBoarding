using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Controllers
{
    //api/educationqualifications
    [Route("api/educationqualifications")]
    [ApiController]
    public class EducationQualificationsController : ControllerBase
    {
        private readonly IEducationQualification _repository;
        private readonly IMapper _mapper;

        public EducationQualificationsController(IEducationQualification repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/educationqualifications
        [HttpGet]
        public ActionResult <IEnumerable<EducationQualificationsReadDto>> GetAllEducationQualifications()
        {
            var educationQualificationItems =  _repository.GetEducationQualifications();

            return Ok(_mapper.Map<IEnumerable<EducationQualificationsReadDto>>(educationQualificationItems));
        }

        //GET api/educationqualifications/{id}
        [HttpGet("{id}", Name="GetEducationQualificationsByEmployeeId")]
        public ActionResult <IEnumerable<EducationQualificationsReadDto>> GetEducationQualificationsByEmployeeId(int id)
        {
            var educationQualificationItems = _repository.GetEducationQualificationsByEmployeeId(id);

            if(educationQualificationItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<EducationQualificationsReadDto>>(educationQualificationItems));
            }

            return NotFound();
        }

        //POST api/educationqualifications
        [HttpPost]
        public ActionResult <IEnumerable<EducationQualificationsReadDto>> CreateEducationQualifications(EducationQualificationsCreateDto educationQualificationsCreateDto) 
        {
            int employeeId = 0;
            var educationQualificationsModel = _mapper.Map<EducationQualification>(educationQualificationsCreateDto);
            _repository.CreateEducationQualifications(educationQualificationsModel);
            _repository.SaveChanges();

            var educationQualificationsReadDto = _mapper.Map<EducationQualificationsReadDto>(educationQualificationsModel);

        //    foreach(var data in educationQualificationsReadDto)
        //    {
                employeeId = educationQualificationsReadDto.PersonalDetailEmployeeId;
            //    break;
            // }    

            return CreatedAtRoute(nameof(GetEducationQualificationsByEmployeeId), 
            new {Id = employeeId}, educationQualificationsReadDto);
        }

        //PUT api/educationqualifications/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEducationQualification(int id, 
                                            EducationQualificationsUpdateDto educationQualificationsUpdateDto)
        {
            // foreach(var educationUpdate in educationQualificationsUpdateDto)
            // {
                EducationQualification educationQualificationModelFromRepo = 
                        _repository.GetEducationQualificationsByEducationId(educationQualificationsUpdateDto.EducationQualificationId);

                if(educationQualificationModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(educationQualificationsUpdateDto, educationQualificationModelFromRepo);

                _repository.UpdateEducationQualifications(educationQualificationModelFromRepo);

                _repository.SaveChanges();
            //}
            return NoContent();
        }

        //PATCH api/educationqualifications/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<EducationQualificationsUpdateDto> patchDocument)
        {
            var educationQualificationModelFromRepo = _repository.GetEducationQualificationsByEducationId(id);

            if(educationQualificationModelFromRepo == null)
            {
                return NotFound();
            }

            var educationQualificationsToPatch = _mapper.Map<EducationQualificationsUpdateDto>(educationQualificationModelFromRepo);

            patchDocument.ApplyTo(educationQualificationsToPatch, ModelState);

            if(!TryValidateModel(educationQualificationsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(educationQualificationsToPatch, educationQualificationModelFromRepo);

            _repository.UpdateEducationQualifications(educationQualificationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/educationqualifications/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEducationQualifications(int id)
        {
             var educationQualificationsModelFromRepo = _repository.GetEducationQualificationsByEducationId(id);

            if(educationQualificationsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEducationQualifications(educationQualificationsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}