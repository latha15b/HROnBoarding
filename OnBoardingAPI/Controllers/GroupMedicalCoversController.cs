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
    //api/groupMedicalCovers
    [Route("api/groupMedicalCovers")]
    [ApiController]
    public class GroupMedicalCoversController : ControllerBase
    {
        private readonly IGroupMedicalCover _repository;
        private readonly IMapper _mapper;
        private readonly IPersonalDetailsRepo _repositoryPersonalDetails;

        private readonly IKid _repositoryKids;

        public GroupMedicalCoversController(IGroupMedicalCover repository, IMapper mapper,IPersonalDetailsRepo repositoryPersonalDetails,
                                               IKid repositoryKids)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryPersonalDetails = repositoryPersonalDetails;
            _repositoryKids = repositoryKids;
        }

        //GET api/groupMedicalCovers
        [HttpGet]
        public ActionResult <IEnumerable<GroupMedicalCoversReadDto>> GetAllGroupMedicalCovers()
        {
            var groupMedicalCoverItems =  _repository.GetGroupMedicalCovers();

            return Ok(_mapper.Map<IEnumerable<GroupMedicalCoversReadDto>>(groupMedicalCoverItems));
        }

        //GET api/groupMedicalCovers/{id}
        [HttpGet("{id}", Name="GetGroupMedicalCoversByGroupMedicalId")]
        public ActionResult <GroupMedicalCoversReadDto> GetGroupMedicalCoversByGroupMedicalId(int id)
        {
            var groupMedicalCoverItems = _repository.GetGroupMedicalCoversByGroupMedicalId(id);

            if(groupMedicalCoverItems != null)
            {
                return Ok(_mapper.Map<GroupMedicalCoversReadDto>(groupMedicalCoverItems));
            }

            return NotFound();
        }

        //POST api/groupMedicalCovers
        [HttpPost]
        public ActionResult <IEnumerable<GroupMedicalCoversReadDto>> CreateGroupMedicalCovers(GroupMedicalCoversCreateDto groupMedicalCoversCreateDto) 
        {
            int groupId = 0;
            string empId = groupMedicalCoversCreateDto.personalDetailEmployeeId.ToString();
            var groupMedicalCoversModel = _mapper.Map<GroupMedicalCover>(groupMedicalCoversCreateDto);
            _repository.CreateGroupMedicalCovers(groupMedicalCoversModel);
            _repository.SaveChanges();

            var groupMedicalCoversReadDto = _mapper.Map<GroupMedicalCoversReadDto>(groupMedicalCoversModel);
            
            // foreach(var data in groupMedicalCoversReadDto)
            // {
                groupId = groupMedicalCoversReadDto.GroupMedicalId;
            //     break;
            // }    


            if(groupId != 0 && Convert.ToInt32(empId) != 0)
            {
                PersonalDetails perFromRepo = _repositoryPersonalDetails.GetPersonalDetailsById(Convert.ToInt32(empId));

                PersonalDetailsUpdateDto personalDetailsUpdateDto = _mapper.Map<PersonalDetailsUpdateDto>(perFromRepo);
            
                personalDetailsUpdateDto.GroupMedicalCoverGroupMedicalId= groupId;
                _mapper.Map(personalDetailsUpdateDto, perFromRepo);
                _repositoryPersonalDetails.UpdatePersonalDetails(perFromRepo);
                _repository.SaveChanges();
            }
            if(groupMedicalCoversCreateDto.DoYouHaveKids)
            {
                _repositoryKids.CreateKids(groupMedicalCoversCreateDto.Kids);
            }
            


            return CreatedAtRoute(nameof(GetGroupMedicalCoversByGroupMedicalId), 
            new {Id = groupId}, groupMedicalCoversReadDto);
        }

        //PUT api/groupMedicalCovers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateGroupMedicalCover(int id, 
                                            IEnumerable<GroupMedicalCoversUpdateDto> groupMedicalCoversUpdateDto)
        {
            foreach(var groupMedicalCoversUpdate in groupMedicalCoversUpdateDto)
            {
                GroupMedicalCover groupMedicalCoverModelFromRepo = 
                        _repository.GetGroupMedicalCoversByGroupMedicalId(groupMedicalCoversUpdate.GroupMedicalId);

                if(groupMedicalCoverModelFromRepo == null)
                {
                    return NotFound();
                }

                _mapper.Map(groupMedicalCoversUpdate, groupMedicalCoverModelFromRepo);

                _repository.UpdateGroupMedicalCovers(groupMedicalCoverModelFromRepo);

                _repository.SaveChanges();
            }
            return NoContent();
        }

        //PATCH api/groupMedicalCovers/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id,JsonPatchDocument<GroupMedicalCoversUpdateDto> patchDocument)
        {
            var groupMedicalCoverModelFromRepo = _repository.GetGroupMedicalCoversByGroupMedicalId(id);

            if(groupMedicalCoverModelFromRepo == null)
            {
                return NotFound();
            }

            var groupMedicalCoversToPatch = _mapper.Map<GroupMedicalCoversUpdateDto>(groupMedicalCoverModelFromRepo);

            patchDocument.ApplyTo(groupMedicalCoversToPatch, ModelState);

            if(!TryValidateModel(groupMedicalCoversToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(groupMedicalCoversToPatch, groupMedicalCoverModelFromRepo);

            _repository.UpdateGroupMedicalCovers(groupMedicalCoverModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/groupMedicalCovers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteGroupMedicalCovers(int id)
        {
             var groupMedicalCoversModelFromRepo = _repository.GetGroupMedicalCoversByGroupMedicalId(id);

            if(groupMedicalCoversModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteGroupMedicalCovers(groupMedicalCoversModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}