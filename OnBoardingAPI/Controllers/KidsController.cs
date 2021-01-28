using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnBoardingAPI.Data;
using OnBoardingAPI.Dtos;
using OnBoardingAPI.Models;


namespace OnBoardingAPI.Controllers
{
    //api/kids
    [Route("api/kids")]
    [ApiController]
    public class KidsController : ControllerBase
    {
        private readonly IKid _repository;
        private readonly IMapper _mapper;

        public KidsController(IKid repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/kids
        [HttpGet]
        public ActionResult <IEnumerable<KidsReadDto>> GetAllKids()
        {
            var KidItems =  _repository.GetKids();

            return Ok(_mapper.Map<IEnumerable<KidsReadDto>>(KidItems));
        }

        //GET api/kids/{id}
        [HttpGet("{id}", Name="GetKidsByGroupMedicalCoverId")]
        public ActionResult <IEnumerable<KidsReadDto>> GetKidsByGroupMedicalCoverId(int id)
        {
            var kidItems = _repository.GetKidsByGroupMedicalCoverId(id);

            if(kidItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<KidsReadDto>>(kidItems));
            }

            return NotFound();
        }

        //POST api/kids
        [HttpPost]
        public ActionResult <IEnumerable<KidsReadDto>> CreateKids(IEnumerable<KidsCreateDto> kidsCreateDto) 
        {
            int groupMedicalCoverId = 0;
            var KidsModel = _mapper.Map<IEnumerable<Kid>>(kidsCreateDto);
            _repository.CreateKids(KidsModel);
            _repository.SaveChanges();

            var KidsReadDto = _mapper.Map<IEnumerable<KidsReadDto>>(KidsModel);

            foreach(var data in KidsReadDto)
            {
                groupMedicalCoverId = data.GroupMedicalCoverGroupMedicalId;
                break;
            }    

            return CreatedAtRoute(nameof(GetKidsByGroupMedicalCoverId), 
            new {Id = groupMedicalCoverId}, KidsReadDto);
        }

        //PUT api/kids/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateKid(int id, 
                                            IEnumerable<KidsUpdateDto> kidsUpdateDto)
        {
            foreach(var kidUpdate in kidsUpdateDto)
            {
                Kid KidModelFromRepo = 
                        _repository.GetKidsByKidId(kidUpdate.KidId);

                if(KidModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(kidUpdate, KidModelFromRepo);

                _repository.UpdateKids(KidModelFromRepo);

                _repository.SaveChanges();
            }
            return NoContent();
        }

        //PATCH api/Kids/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, 
                                JsonPatchDocument<KidsUpdateDto> patchDocument)
        {
            var KidModelFromRepo = _repository.GetKidsByKidId(id);

            if(KidModelFromRepo == null)
            {
                return NotFound();
            }

            var KidsToPatch = _mapper.Map<KidsUpdateDto>(KidModelFromRepo);

            patchDocument.ApplyTo(KidsToPatch, ModelState);

            if(!TryValidateModel(KidsToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(KidsToPatch, KidModelFromRepo);

            _repository.UpdateKids(KidModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Kids/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteKids(int id)
        {
             var KidsModelFromRepo = _repository.GetKidsByKidId(id);

            if(KidsModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteKids(KidsModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        
    }
}