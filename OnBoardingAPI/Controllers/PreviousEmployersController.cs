using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;

namespace OnBoardingAPI.Controllers
{
    //api/previousEmployers
    [Route("api/previousEmployers")]
    [ApiController]
    public class PreviousEmployersController : ControllerBase
    {
        private readonly IPreviousEmployer _repository;
        private readonly IMapper _mapper;

        public PreviousEmployersController(IPreviousEmployer repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/previousEmployers
        [HttpGet]
        public ActionResult <IEnumerable<PreviousEmployersReadDto>> GetAllPreviousEmployers()
        {
            var previousEmployerItems =  _repository.GetPreviousEmployers();

            return Ok(_mapper.Map<IEnumerable<PreviousEmployersReadDto>>(previousEmployerItems));
        }

        //GET api/previousEmployers/{id}
        [HttpGet("{id}", Name="GetPreviousEmployersByEmployeeId")]
        public ActionResult <IEnumerable<PreviousEmployersReadDto>> GetPreviousEmployersByEmployeeId(int id)
        {
            var previousEmployerItems = _repository.GetPreviousEmployersByEmployeeId(id);

            if(previousEmployerItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<PreviousEmployersReadDto>>(previousEmployerItems));
            }

            return NotFound();
        }

        //POST api/previousEmployers
        [HttpPost]
        public ActionResult <IEnumerable<PreviousEmployersReadDto>> CreatePreviousEmployers(PreviousEmployersCreateDto previousEmployersCreateDto) 
        {
            int employeeId = 0;
            var previousEmployersModel = _mapper.Map<PreviousEmployer>(previousEmployersCreateDto);
            _repository.CreatePreviousEmployers(previousEmployersModel);
            _repository.SaveChanges();

            var previousEmployersReadDto = _mapper.Map<PreviousEmployersReadDto>(previousEmployersModel);

            // foreach(var data in previousEmployersReadDto)
            // {
                   employeeId = previousEmployersReadDto.PersonalDetailEmployeeId;
            //     break;
            // }    

            return CreatedAtRoute(nameof(GetPreviousEmployersByEmployeeId), 
            new {Id = employeeId}, previousEmployersReadDto);
        }

        //PUT api/previousEmployers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePreviousEmployer(int id, PreviousEmployersUpdateDto previousEmployersUpdateDto)
        {
            // foreach(var previousEmployerUpdate in previousEmployersUpdateDto)
            // {
                PreviousEmployer previousEmployerModelFromRepo = 
                        _repository.GetPreviousEmployersByPreviousEmployerId(previousEmployersUpdateDto.PreviousEmployerId);

                if(previousEmployerModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(previousEmployersUpdateDto, previousEmployerModelFromRepo);

                _repository.UpdatePreviousEmployers(previousEmployerModelFromRepo);

                _repository.SaveChanges();
            //}
            return NoContent();
        }

        //PATCH api/previousEmployers/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<PreviousEmployersUpdateDto> patchDocument)
        {
            var previousEmployerModelFromRepo = _repository.GetPreviousEmployersByPreviousEmployerId(id);

            if(previousEmployerModelFromRepo == null)
            {
                return NotFound();
            }

            var previousEmployersToPatch = _mapper.Map<PreviousEmployersUpdateDto>(previousEmployerModelFromRepo);

            patchDocument.ApplyTo(previousEmployersToPatch, ModelState);

            if(!TryValidateModel(previousEmployersToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(previousEmployersToPatch, previousEmployerModelFromRepo);

            _repository.UpdatePreviousEmployers(previousEmployerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/previousEmployers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePreviousEmployers(int id)
        {
             var previousEmployersModelFromRepo = _repository.GetPreviousEmployersByPreviousEmployerId(id);

            if(previousEmployersModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePreviousEmployers(previousEmployersModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}