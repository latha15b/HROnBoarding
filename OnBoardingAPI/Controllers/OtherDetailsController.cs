using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;
using System;

namespace OnBoardingAPI.Controllers
{
    //api/otherDetails
    [Route("api/otherDetails")]
    [ApiController]
    public class OtherDetailsController : ControllerBase
    {
        private readonly IOtherDetails _repository;
        private readonly IMapper _mapper;
        private readonly IPersonalDetailsRepo _repositoryPersonalDetails;
        public OtherDetailsController(IOtherDetails repository, IMapper mapper, IPersonalDetailsRepo repositoryPersonalDetails)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryPersonalDetails = repositoryPersonalDetails;
        }

        //GET api/otherDetails
        [HttpGet]
        public ActionResult <IEnumerable<OtherDetailsReadDto>> GetAllOtherDetails()
        {
            var otherDetailsItems =  _repository.GetOtherDetails();

            return Ok(_mapper.Map<IEnumerable<OtherDetailsReadDto>>(otherDetailsItems));
        }

        //GET api/otherDetails/{id}
        [HttpGet("{id}", Name="GetOtherDetailsByEmployeeId")]
        public ActionResult <IEnumerable<OtherDetailsReadDto>> GetOtherDetailsByEmployeeId(int id)
        {
            var otherDetailsItems = _repository.GetOtherDetailsByEmployeeId(id);

            if(otherDetailsItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<OtherDetailsReadDto>>(otherDetailsItems));
            }

            return NotFound();
        }

        //POST api/otherDetails
        [HttpPost]
        public ActionResult <IEnumerable<OtherDetailsReadDto>> CreateOtherDetails(OtherDetailsCreateDto otherDetailsCreateDto) 
        {
            int otherDetailsId = 0;
            string empId = otherDetailsCreateDto.PersonalDetailEmployeeId.ToString();
            var otherDetailsModel = _mapper.Map<OtherDetails>(otherDetailsCreateDto);
            _repository.CreateOtherDetails(otherDetailsModel);
            _repository.SaveChanges();

            var otherDetailsReadDto = _mapper.Map<OtherDetailsReadDto>(otherDetailsModel);

            // foreach(var data in otherDetailsReadDto)
            // {
                   otherDetailsId = otherDetailsReadDto.OtherDetailsId;
            //     break;
            // }    
            if(otherDetailsId != 0 && Convert.ToInt32(empId) != 0)
            {
                PersonalDetails perFromRepo = _repositoryPersonalDetails.GetPersonalDetailsById(Convert.ToInt32(empId));

                PersonalDetailsUpdateDto personalDetailsUpdateDto = _mapper.Map<PersonalDetailsUpdateDto>(perFromRepo);
            
                personalDetailsUpdateDto.OtherDetailsId= otherDetailsId;
                _mapper.Map(personalDetailsUpdateDto, perFromRepo);
                _repositoryPersonalDetails.UpdatePersonalDetails(perFromRepo);
                _repository.SaveChanges();
            }
            return CreatedAtRoute(nameof(GetOtherDetailsByEmployeeId), 
            new {Id = otherDetailsId}, otherDetailsReadDto);
        }

        //PUT api/otherDetails/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOtherDetails(int id, IEnumerable<OtherDetailsUpdateDto> otherDetailsUpdateDto)
        {
            foreach(var otherDetailsUpdate in otherDetailsUpdateDto)
            {
                OtherDetails previousEmployerModelFromRepo = 
                        _repository.GetOtherDetailsById(otherDetailsUpdate.OtherDetailsId);

                if(previousEmployerModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(otherDetailsUpdate, previousEmployerModelFromRepo);

                _repository.UpdateOtherDetails(previousEmployerModelFromRepo);

                _repository.SaveChanges();
            }
            return NoContent();
        }

        //PATCH api/otherDetails/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<OtherDetailsUpdateDto> patchDocument)
        {
            var previousEmployerModelFromRepo = _repository.GetOtherDetailsById(id);

            if(previousEmployerModelFromRepo == null)
            {
                return NotFound();
            }

            var otherDetailsToPatch = _mapper.Map<OtherDetailsUpdateDto>(previousEmployerModelFromRepo);

            patchDocument.ApplyTo(otherDetailsToPatch, ModelState);

            if(!TryValidateModel(otherDetailsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(otherDetailsToPatch, previousEmployerModelFromRepo);

            _repository.UpdateOtherDetails(previousEmployerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/otherDetails/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOtherDetails(int id)
        {
             var otherDetailsModelFromRepo = _repository.GetOtherDetailsById(id);

            if(otherDetailsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteOtherDetails(otherDetailsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}