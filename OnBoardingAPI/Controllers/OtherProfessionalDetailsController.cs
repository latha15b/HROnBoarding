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
    //api/otherProfessionalDetails
    [Route("api/otherProfessionalDetails")]
    [ApiController]
    public class OtherProfessionalDetailsController : ControllerBase
    {
        private readonly IOtherProfessionalDetails _repository;
        private readonly IMapper _mapper;
        private readonly IPersonalDetailsRepo _repositoryPersonalDetails;
        public OtherProfessionalDetailsController(IOtherProfessionalDetails repository, IMapper mapper,IPersonalDetailsRepo repositoryPersonalDetails)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryPersonalDetails = repositoryPersonalDetails;
        }

        //GET api/otherProfessionalDetails
        [HttpGet]
        public ActionResult <IEnumerable<OtherProfessionalDetailsReadDto>> GetAllOtherProfessionalDetails()
        {
            var otherProfessionalDetailsItems =  _repository.GetOtherProfessionalDetails();

            return Ok(_mapper.Map<IEnumerable<OtherProfessionalDetailsReadDto>>(otherProfessionalDetailsItems));
        }

        //GET api/otherProfessionalDetails/{id}
        [HttpGet("{id}", Name="GetOtherProfessionalDetailsByEmployeeId")]
        public ActionResult <IEnumerable<OtherProfessionalDetailsReadDto>> GetOtherProfessionalDetailsByEmployeeId(int id)
        {
            var otherProfessionalDetailsItems = _repository.GetOtherProfessionalDetailsByEmployeeId(id);

            if(otherProfessionalDetailsItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<OtherProfessionalDetailsReadDto>>(otherProfessionalDetailsItems));
            }

            return NotFound();
        }

        //GET api/personaldetails/GetAllRatingLevelDetails
        [HttpGet]
        [Route("GetAllRatingLevelDetails")]        
        public ActionResult <IEnumerable<RatingLevelReadDto>> GetAllRatingLevelDetails()
        {
            var ratingLevelItems = _repository.GetAllRatingLevelDetails();

            return Ok(_mapper.Map<IEnumerable<RatingLevelReadDto>>(ratingLevelItems));
        }

        //POST api/otherProfessionalDetails
        [HttpPost]
        public ActionResult <IEnumerable<OtherProfessionalDetailsReadDto>> CreateOtherProfessionalDetails(OtherProfessionalDetailsCreateDto otherProfessionalDetailsCreateDto) 
        {
            int otherProfessionalDetailsId = 0;
            string empId = otherProfessionalDetailsCreateDto.PersonalDetailEmployeeId.ToString();
            var otherProfessionalDetailsModel = _mapper.Map<OtherProfessionalDetails>(otherProfessionalDetailsCreateDto);
            _repository.CreateOtherProfessionalDetails(otherProfessionalDetailsModel);
            _repository.SaveChanges();

            var otherProfessionalDetailsReadDto = _mapper.Map<OtherProfessionalDetailsReadDto>(otherProfessionalDetailsModel);

            // foreach(var data in otherProfessionalDetailsReadDto)
            // {
                   otherProfessionalDetailsId = otherProfessionalDetailsReadDto.OtherProfessionalDetailsId;
            //     break;
            // }    

            if(otherProfessionalDetailsId != 0 && Convert.ToInt32(empId) != 0)
            {
                PersonalDetails perFromRepo = _repositoryPersonalDetails.GetPersonalDetailsById(Convert.ToInt32(empId));

                PersonalDetailsUpdateDto personalDetailsUpdateDto = _mapper.Map<PersonalDetailsUpdateDto>(perFromRepo);
            
                personalDetailsUpdateDto.OtherProfessionalDetailsId= otherProfessionalDetailsId;
                _mapper.Map(personalDetailsUpdateDto, perFromRepo);
                _repositoryPersonalDetails.UpdatePersonalDetails(perFromRepo);
                _repository.SaveChanges();
            }
            return CreatedAtRoute(nameof(GetOtherProfessionalDetailsByEmployeeId), 
            new {Id = otherProfessionalDetailsId}, otherProfessionalDetailsReadDto);
        }

        //PUT api/otherProfessionalDetails/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOtherProfessionalDetails(int id, IEnumerable<OtherProfessionalDetailsUpdateDto> otherProfessionalDetailsUpdateDto)
        {
            foreach(var otherProfessionalDetailsUpdate in otherProfessionalDetailsUpdateDto)
            {
                OtherProfessionalDetails previousEmployerModelFromRepo = 
                        _repository.GetOtherProfessionalDetailsById(otherProfessionalDetailsUpdate.OtherProfessionalDetailsId);

                if(previousEmployerModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(otherProfessionalDetailsUpdate, previousEmployerModelFromRepo);

                _repository.UpdateOtherProfessionalDetails(previousEmployerModelFromRepo);

                _repository.SaveChanges();
            }
            return NoContent();
        }

        //PATCH api/otherProfessionalDetails/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<OtherProfessionalDetailsUpdateDto> patchDocument)
        {
            var previousEmployerModelFromRepo = _repository.GetOtherProfessionalDetailsById(id);

            if(previousEmployerModelFromRepo == null)
            {
                return NotFound();
            }

            var otherProfessionalDetailsToPatch = _mapper.Map<OtherProfessionalDetailsUpdateDto>(previousEmployerModelFromRepo);

            patchDocument.ApplyTo(otherProfessionalDetailsToPatch, ModelState);

            if(!TryValidateModel(otherProfessionalDetailsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(otherProfessionalDetailsToPatch, previousEmployerModelFromRepo);

            _repository.UpdateOtherProfessionalDetails(previousEmployerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/otherProfessionalDetails/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOtherProfessionalDetails(int id)
        {
             var otherProfessionalDetailsModelFromRepo = _repository.GetOtherProfessionalDetailsById(id);

            if(otherProfessionalDetailsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteOtherProfessionalDetails(otherProfessionalDetailsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}