using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using NZWalks.API.CustomerActionFilters;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    // https://localhost:MSSQLSERVER01/api/regions
    [Route("api/[controller]")]
    [ApiController]

    public class RegionsController : ControllerBase
    {

        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper,
            ILogger<RegionsController> logger) 
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        //GET ALL REGIONS
        //GET: https://localhost:MSSQLSERVER01/api/regions
        [HttpGet]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                // Get Data From Database -- Using Domain Models
                var regionsDomain = await regionRepository.GetAllAsync();

                //Map Domain Models to DTOs by automapper
                var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

                //Return DTOs

                logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");
                return Ok(regionsDto);
            }
            catch   (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }

        }




        // GET SINGLE REGION (Get Region By Id)
        // GET: https://localhost:MSSQLSERVER01/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);// Find() only used for primary key
            
            //Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id); // test 88513bdb-3365-40b7-bf6f-0d5ff9029f32

            if (regionDomain == null)
                return NotFound();

            // Map or Convert Region Domain Model to DTO
            var regionsDto = mapper.Map<List<RegionDto>>(regionDomain);
            
            return Ok(regionsDto);
            //return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }




        //POST To Create New Region
        //POST: https://localhost:MSSQLSERVER01/api/regions
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

                // Map or Convert DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                //Use Domain Model to create Region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);


                //Map Domain model back to DTO
                var regionsDto = mapper.Map<Region>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id }, regionsDto);



        }



        //Update region
        //PUT: https://localhost:MSSQLSERVER01/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
                // Map DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                //Check if region exits
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                //Convert Domain Model to DTO
                var regionDto = mapper.Map<Region>(regionDomainModel);

                return Ok(regionDto);


        }



        //Delete Region
        //DELETE: https://localhost:MSSQLSERVER01/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }


            //return delete Region back
            //map Domain Model to DTO
            var regionDto = mapper.Map<Region>(regionDomainModel);

            return Ok(regionDto);
        }



    }
}


//  "username": "reader@example.com",
//"password": "Reader@123"


