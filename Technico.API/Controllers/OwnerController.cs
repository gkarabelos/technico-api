using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Technico.Core.DTOs.Owner;
using Technico.Core.Interfaces;

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
        public async Task<ActionResult<OwnerDto>> CreatePropertyOwner([FromBody] CreateOwnerDto dto)
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

        [HttpGet("validate-owner-vat/{vatNumber}")]
        public async Task<IActionResult> ValidateOwnerVat(string vatNumber)
        {
            var owner = await _ownerService.FindByVatNumberAsync(vatNumber);
            if (owner == null)
                return NotFound(new { message = "Owner with the provided VAT number does not exist." });

            return Ok(new { message = "Owner with the provided VAT number does exist.", id = owner.Id });
        }

        [HttpGet("login/{email}")]
        public async Task<IActionResult> CheckOwnerByEmail(string email)
        {
            var exists = await _ownerService.ExistsByEmailAsync(email);
            return Ok(new { exists });
        }

    }
}
