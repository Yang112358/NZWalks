using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{

    // https://localhost:7196/api/studdents
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET: https://localhost:7196/api/studdents
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentName = new string[] { "John", "Jane", "Mark", "Emily", "David" };

            return Ok(studentName);

        }


    }
}
