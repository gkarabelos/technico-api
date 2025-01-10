using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Technico.Core.DTOs.Property;
using Technico.Core.Interfaces;

namespace Technico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetAllProperties()
        {
            var properties = await _propertyService.GetPropertiesAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetPropertyById(long id)
        {
            var property = await _propertyService.GetByIdAsync(id);
            if (property == null)
                return NotFound();
            return Ok(property);
        }

        [HttpPost]
        public async Task<ActionResult<PropertyDto>> CreateProperty([FromBody] CreatePropertyDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var property = await _propertyService.CreatePropertyAsync(dto);
                return CreatedAtAction(nameof(GetPropertyById), new { id = property.Id }, property);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(long id, [FromBody] UpdatePropertyDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var success = await _propertyService.UpdatePropertyAsync(id, dto);
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
        public async Task<IActionResult> DeleteProperty(long id)
        {
            var success = await _propertyService.DeletePropertyAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedProperties([FromQuery] string? searchTerm = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _propertyService.GetPaginatedPropertiesAsync(searchTerm, page, pageSize);
            return Ok(result);
        }
    }
}
