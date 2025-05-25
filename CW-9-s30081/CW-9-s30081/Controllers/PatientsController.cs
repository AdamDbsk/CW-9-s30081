using CW_9_s30081.DTOs;
using CW_9_s30081.Exceptions;
using CW_9_s30081.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_s30081.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController(IDBService service) : Controller {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientInfo([FromRoute] int id) {
            try {

                return Ok(await service.GetPatientDetailsByIdAsync(id));
            } catch (NotFoundException e) {
                return NotFound(e.Message);
            }
        }
    }
}
