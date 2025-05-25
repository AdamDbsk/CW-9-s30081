using CW_9_s30081.DTOs;
using CW_9_s30081.Exceptions;
using CW_9_s30081.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_s30081.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrescriptionsController(IDBService service) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionCreateDTO prescriptionCreateDTO) {
            try {

                var prescription = await service.CreateNewPrescription(prescriptionCreateDTO);
                return Created($"prescriptions/{prescription.PerscriptionID}", prescription);
            } catch (NotFoundException e) {
                return NotFound(e.Message);
            }
        }
    }
}
