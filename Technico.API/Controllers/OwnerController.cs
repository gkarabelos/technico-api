using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Technico.Core.DTOs.Owner;
using Technico.Core.Interfaces;
using Technico.Data.Repositories;

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

        [HttpPost("login")]
        public async Task<IActionResult> ValidateEmailAndPassword([FromQuery] string email, [FromQuery] string password)
        {
            var emailExists = await _ownerService.ValidateEmailAsync(email);
            if (!emailExists)
            {
                return Ok(new { isValid = false, message = "Email does not exist." });
            }
            var isPasswordCorrect = await _ownerService.ValidatePasswordAsync(email, password);
            if (!isPasswordCorrect)
            {
                return Ok(new { isValid = false, message = "Wrong password." });
            }
            return Ok(new { isValid = true, message = "Validation successful." });
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetFilteredOwners([FromQuery] string? vatNumber, [FromQuery] string? email)
        {
            var owners = await _ownerService.GetFilteredOwnersAsync(vatNumber, email);
            return Ok(owners);
        }
    }
}
