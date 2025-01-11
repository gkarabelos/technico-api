

using Technico.Core.Enums;

namespace Technico.Core.DTOs.Property
{
    public class CreatePropertyDto
    {
        public string E9 { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int YearOfConstruction { get; set; }

        public PropertyType Type { get; set; }

        public long OwnerId { get; set; }
    }
}
