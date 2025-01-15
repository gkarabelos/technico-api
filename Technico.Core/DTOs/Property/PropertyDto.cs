using Technico.Core.DTOs.Owner;
using Technico.Core.Enums;

namespace Technico.Core.DTOs.Property
{
    public class PropertyDto
    {
        public long Id { get; set; }

        public string E9 { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int YearOfConstruction { get; set; }

        public PropertyType Type { get; set; }

        public bool IsActive { get; set; }

        public string? VatNumber { get; set; }
    }
}
