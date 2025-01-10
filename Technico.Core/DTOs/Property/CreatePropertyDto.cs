

namespace Technico.Core.DTOs.Property
{
    public class CreatePropertyDto
    {
        public string PropertyId { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int YearOfConstruction { get; set; }

        public string Type { get; set; } = null!;

        public long OwnerId { get; set; }
    }
}
