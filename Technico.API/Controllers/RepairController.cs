using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Technico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService _repairService;

        public RepairController(IRepairService repairService)
        {
            _repairService = repairService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairDto>>> GetAllRepairs()
        {
            var repairs = await _repairService.GetRepairsAsync();
            return Ok(repairs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepairDto>> GetRepairById(long id)
        {
            var repair = await _repairService.GetByIdAsync(id);
            if (repair == null)
                return NotFound();
            return Ok(repair);
        }

        [HttpPost]
        public async Task<ActionResult<RepairDto>> CreateRepair([FromBody] CreateRepairDto dto) // Maybe change to Repair(Request/Response)Dto
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var repair = await _repairService.CreateRepairAsync(dto);
                return CreatedAtAction(nameof(GetRepairById), new { id = repair.Id }, repair);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepair(long id, [FromBody] UpdateRepairDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var success = await _repairService.UpdateRepairAsync(id, dto);
                if (!success)
                    return NotFound();
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(long id)
        {
            var success = await _repairService.DeleteRepairAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
