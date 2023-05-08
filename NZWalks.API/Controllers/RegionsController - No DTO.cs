//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
//using NZWalks.API.Data;
//using NZWalks.API.Models.Domain;
//using NZWalks.API.Models.DTO;

//namespace NZWalks.API.Controllers
//{
//    // https://localhost:MSSQLSERVER01/api/regions
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RegionsController : ControllerBase
//    {

//        private readonly NZWalksDbContext dbContext;


//        public RegionsController(NZWalksDbContext dbContext) 
//        {
//            this.dbContext = dbContext;   

//        }
//        //GET ALL REGIONS
//        //GET: https://localhost:MSSQLSERVER01/api/regions
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            // Get Data From Database -- Using Domain Models
//            var regionsDomain = await dbContext.Regions.ToListAsync();

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
//            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync((x => x.Id == id)); // test 88513bdb-3365-40b7-bf6f-0d5ff9029f32

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
//            await dbContext.Regions.AddAsync(regionDomainModel);
//            await dbContext.SaveChangesAsync(); // Only with this code will the model save the date into the sql server

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
//            //Check if region exits
//            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

//            if (regionDomainModel == null)
//            {
//                return NotFound();
//            }

//            //Map DTO to Domain Model
//            regionDomainModel.Code = updateRegionRequestDto.Code;
//            regionDomainModel.Name = updateRegionRequestDto.Name;
//            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

//            await dbContext.SaveChangesAsync();

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
//            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

//            if(regionDomainModel == null)
//            {
//                return NotFound();
//            }

//            //Delete Region
//            dbContext.Regions.Remove(regionDomainModel);
//            await dbContext.SaveChangesAsync();

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







//        //// A hard code test.
//        //public IActionResult GetAll()
//        //{
//        //    var regions = new List<Region>
//        //    {
//        //        new Region
//        //        {
//        //            Id = Guid.NewGuid(),
//        //            Name = "Auckland Region",
//        //            Code = "AKL",
//        //            RegionImageUrl = "1234"
//        //        },
//        //        new Region
//        //        {
//        //            Id = Guid.NewGuid(),
//        //            Name = "Wel Region",
//        //            Code = "WLG",
//        //            RegionImageUrl = "1234"

//        //        }
//        //    };
//        //    return Ok(regions);
//        //}
//    }
//}
