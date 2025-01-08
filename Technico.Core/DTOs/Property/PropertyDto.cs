using Technico.Core.DTOs.Owner;

namespace Technico.Core.DTOs.Property
{
    public class PropertyDto
    {
        public long Id { get; set; }

        public string PropertyId { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int YearOfConstruction { get; set; }

        public string Type { get; set; } = null!;

        public OwnerDto Owner { get; set; } = null!;
    }
}
