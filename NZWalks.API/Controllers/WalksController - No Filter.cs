﻿//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using NZWalks.API.CustomerActionFilters;
//using NZWalks.API.Models.Domain;
//using NZWalks.API.Models.DTO;
//using NZWalks.API.Repositories;


//namespace NZWalks.API.Controllers
//{
//    // /api/walks
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WalksController : ControllerBase
//    {
//        private readonly IMapper mapper;
//        private readonly IWalkRepository walkRepository;

//        public WalksController(IMapper mapper, IWalkRepository walkRepository)
//        {
//            this.mapper = mapper;
//            this.walkRepository = walkRepository;
//        }



//        //CREATE Walk
//        //POST: /api/walks
//        [HttpPost]
//        [ValidateModel]
//        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
//        {
//                // Map DTO to Domain Model
//                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

//                await walkRepository.CreateAsync(walkDomainModel);

//                // Map domain model to DTO.
//                return Ok();

//        }


//        //GET Walks
//        //GET: /api/walks
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var walksDomainModel = await walkRepository.GetAllAsync();

//            //Map Domain Model to DTO
//            return Ok(mapper.Map<List<WalkDto>> (walksDomainModel)); 
//        }

//        //GET Walk By Id
//        //GET: /api/Walks/{id} 
//        [HttpGet]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> GetById([FromRoute] Guid id)
//        {
//            var walkDomainModel = await walkRepository.GetByIdAsync(id);

//            if (walkDomainModel == null)
//            {
//                return NotFound();
//            }

//            //map Domain Model to DTO
//            return Ok(mapper.Map<WalkDto>(walkDomainModel));

//        }

//        //UPDATE Walk By Id
//        //PUT: /api/Walks/{id}
//        [HttpPut]
//        [Route("{id:Guid}")]
//        [ValidateModel]
//        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
//        {
//                //Map DTO to Domain Model
//                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

//                await walkRepository.UpdateAsync(id, walkDomainModel);

//                if (walkDomainModel == null)
//                {
//                    return NotFound();
//                }

//                //Map Domian Model to Dto
//                return Ok(mapper.Map<WalkDto>(walkDomainModel));

//        }


//        //DELETE a Walk By Id
//        //DELETE: /api/Walks/{id}
//        [HttpDelete]
//        [Route("{id:Guid}")]

//        public async Task<IActionResult> Delete([FromRoute] Guid id)
//        {
//            var deleteWalkDomainModel = await walkRepository.DeleteAsync(id);

//            if(deleteWalkDomainModel == null)
//            {
//                return NotFound();
//            }

//            //Map Domain Model to Dto
//            return Ok(mapper.Map<WalkDto>(deleteWalkDomainModel));
//        }


//    }
//}
