//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
//using NZWalks.API.Data;
//using NZWalks.API.Models.Domain;
//using NZWalks.API.Models.DTO;
//using NZWalks.API.Repositories;

//namespace NZWalks.API.Controllers
//{
//    // https://localhost:MSSQLSERVER01/api/regions
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RegionsController : ControllerBase
//    {

//        private readonly NZWalksDbContext dbContext;
//        private readonly IRegionRepository regionRepository;

//        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository) 
//        {
//            this.dbContext = dbContext;
//            this.regionRepository = regionRepository;
//        }
//        //GET ALL REGIONS
//        //GET: https://localhost:MSSQLSERVER01/api/regions
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            // Get Data From Database -- Using Domain Models
//            var regionsDomain = await regionRepository.GetAllAsync();

//            // Map Domain Models to DTOS
//            var regionsDto = new List<RegionDto>();
//            foreach (var regionDomain in regionsDomain)
//            {
//                regionsDto.Add(new RegionDto()
//                {
//                    Id = regionDomain.Id,
//                    Name = regionDomain.Name,
//                    Code = regionDomain.Code,
//                    RegionImageUrl = regionDomain.RegionImageUrl
//                });
//            }


//            //Return DTOs
//            return Ok(regionsDto);
//        }




//        // GET SINGLE REGION (Get Region By Id)
//        // GET: https://localhost:MSSQLSERVER01/api/regions/{id}
//        [HttpGet]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> GetById([FromRoute] Guid id)
//        {
//            //var region = dbContext.Regions.Find(id);// Find() only used for primary key
            
//            //Get Region Domain Model From Database
//            var regionDomain = await regionRepository.GetByIdAsync(id); // test 88513bdb-3365-40b7-bf6f-0d5ff9029f32

//            if (regionDomain == null)
//                return NotFound();
//            // Map or Convert Region Domain Model to DTO
//            var regionsDto = new List<RegionDto>();
//            regionsDto.Add(new RegionDto()
//            {
//                Id = regionDomain.Id,
//                Name = regionDomain.Name,
//                Code = regionDomain.Code,
//                RegionImageUrl = regionDomain.RegionImageUrl
//            });
//            return Ok(regionsDto);
//        }




//        //POST To Create New Region
//        //POST: https://localhost:MSSQLSERVER01/api/regions
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
//        {
//            // Map or Convert DTO to Domain Model
//            var regionDomainModel = new Region
//            {
//                Code = addRegionRequestDto.Code,
//                Name = addRegionRequestDto.Name,
//                RegionImageUrl = addRegionRequestDto.RegionImageUrl
//            };
//            //Use Domain Model to create Region
//            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);


//            //Map Domain model back to DTO
//            var regionsDto = new RegionDto
//            {
//                Id = regionDomainModel.Id,
//                Code = addRegionRequestDto.Code,
//                Name = addRegionRequestDto.Name,
//                RegionImageUrl = addRegionRequestDto.RegionImageUrl
//            };

//            return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id }, regionsDto);
//        }



//        //Update region
//        //PUT: https://localhost:MSSQLSERVER01/api/regions/{id}
//        [HttpPut]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
//        {

//            // Map DTO to Domain Model
//            var regionDomainModel = new Region
//            {
//                Code = updateRegionRequestDto.Code,
//                Name = updateRegionRequestDto.Name,
//                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
//            };



//            //Check if region exits
//            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);


//            //Convert Domain Model to DTO
//            var regionDto = new RegionDto
//            {
//                Id = regionDomainModel.Id,
//                Code = regionDomainModel.Code,
//                Name = regionDomainModel.Name,
//                RegionImageUrl = regionDomainModel.RegionImageUrl
//            };
             
//            return Ok(regionDto);

//        }



//        //Delete Region
//        //DELETE: https://localhost:MSSQLSERVER01/api/regions/{id}
//        [HttpDelete]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> Delete([FromRoute] Guid id)
//        {
//            var regionDomainModel = await regionRepository.DeleteAsync(id);

//            if(regionDomainModel == null)
//            {
//                return NotFound();
//            }


//            //return delete Region back
//            //map Domain Model to DTO
//            var regionDto = new RegionDto
//            {
//                Id = regionDomainModel.Id,
//                Name = regionDomainModel.Name,
//                Code = regionDomainModel.Code,
//                RegionImageUrl = regionDomainModel.RegionImageUrl
//            };

//            return Ok(regionDto);
//        }



//    }
//}
