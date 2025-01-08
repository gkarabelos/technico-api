using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Technico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetAllOwners()
        {
            var owners = await _ownerService.GetOwnersAsync();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> GetOwnerById(long id)
        {
            var owner = await _ownerService.GetByIdAsync(id);
            if (owner == null)
                return NotFound();
            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult<OwnerDto>> CreatePropertyOwner([FromBody] CreateOwnerDto dto) // Maybe change to Owner(Request/Response)Dto
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var owner = await _ownerService.CreateOwnerAsync(dto);
                return CreatedAtAction(nameof(GetOwnerById), new { id = owner.Id }, owner);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePropertyOwner(long id, [FromBody] UpdateOwnerDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var success = await _ownerService.UpdateOwnerAsync(id, dto);
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
        public async Task<IActionResult> DeleteOwner(long id)
        {
            var success = await _ownerService.DeleteOwnerAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
