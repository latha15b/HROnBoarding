using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Controllers
{
    //api/personaldetails
    [Route("api/personaldetails")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalDetailsRepo _repository;
        private readonly IMapper _mapper;

        public PersonalDetailsController(IPersonalDetailsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/personaldetails
        [HttpGet]
        public ActionResult <IEnumerable<PersonalDetailsReadDto>> GetAllPersonalDetails()
        {
            var personaldetailsItems =  _repository.GetAllPersonalDetails();

            return Ok(_mapper.Map<IEnumerable<PersonalDetailsReadDto>>(personaldetailsItems));
        }

        //GET api/personaldetails/GetAllStateDetails
        [HttpGet]
        [Route("GetAllStateDetails")]        
        public ActionResult <IEnumerable<StateReadDto>> GetAllStateDetails()
        {
            var stateDetailsItems = _repository.GetAllStateDetails();

            return Ok(_mapper.Map<IEnumerable<StateReadDto>>(stateDetailsItems));
        }

        //GET api/personaldetails/GetAllCityDetailsById/1
        [HttpGet]
        [Route("GetAllCityDetailsById/{stateId}")]        
        public ActionResult <IEnumerable<CityReadDto>> GetAllCityDetailsById(int stateId)
        {
            var cityDetailsItems = _repository.GetAllCityDetails(stateId);

            return Ok(_mapper.Map<IEnumerable<CityReadDto>>(cityDetailsItems));
        }

        //GET api/personaldetails/GetAllCityDetailsByStateName/""
        [HttpGet]
        [Route("GetAllCityDetailsByStateName/{stateName}")]        
        public ActionResult <IEnumerable<CityReadDto>> GetAllCityDetailsByStateName(string stateName)
        {
            var cityDetailsItems = _repository.GetAllCityDetailsByStateName(stateName);

            return Ok(_mapper.Map<IEnumerable<CityReadDto>>(cityDetailsItems));
        }

        //GET api/personaldetails/{id}
        [HttpGet("{id}", Name="GetPersonalDetailsById")]
        public ActionResult <PersonalDetailsReadDto> GetPersonalDetailsById(int id)
        {
            var personalDetailsItems = _repository.GetPersonalDetailsById(id);

            if(personalDetailsItems != null)
            {
                return Ok(_mapper.Map<PersonalDetailsReadDto>(personalDetailsItems));
            }

            return NotFound();
        }

        //POST api/personaldetails
        [HttpPost]
        public ActionResult <PersonalDetailsReadDto> CreatePersonalDetails(PersonalDetailsCreateDto personalDetailsCreateDto) 
        {
            var personalDetailsModel = _mapper.Map<PersonalDetails>(personalDetailsCreateDto);
            _repository.CreatePersonalDetails(personalDetailsModel);
            _repository.SaveChanges();

            var personalDetailsReadDto = _mapper.Map<PersonalDetailsReadDto>(personalDetailsModel);

            return CreatedAtRoute(nameof(GetPersonalDetailsById), 
            new {Id = personalDetailsReadDto.EmployeeId}, personalDetailsReadDto);
        }

        //PUT api/personaldetails/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePersonalDetails(int id, 
                                                  PersonalDetailsUpdateDto personalDetailsUpdateDto)
        {
            var personalDetailsModelFromRepo = _repository.GetPersonalDetailsById(id);

            if(personalDetailsModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(personalDetailsUpdateDto, personalDetailsModelFromRepo);

            _repository.UpdatePersonalDetails(personalDetailsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/personaldetails/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<PersonalDetailsUpdateDto> patchDocument)
        {
             var personalDetailsModelFromRepo = _repository.GetPersonalDetailsById(id);

            if(personalDetailsModelFromRepo == null)
            {
                return NotFound();
            }

            var personalDetailsToPatch = _mapper.Map<PersonalDetailsUpdateDto>(personalDetailsModelFromRepo);

            patchDocument.ApplyTo(personalDetailsToPatch, ModelState);

            if(!TryValidateModel(personalDetailsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(personalDetailsToPatch, personalDetailsModelFromRepo);

            _repository.UpdatePersonalDetails(personalDetailsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/personaldetails/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePersonalDetails(int id)
        {
             var personalDetailsModelFromRepo = _repository.GetPersonalDetailsById(id);

            if(personalDetailsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePersonalDetails(personalDetailsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}