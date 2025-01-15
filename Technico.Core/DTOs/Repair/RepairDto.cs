using Technico.Core.Enums;

namespace Technico.Core.DTOs.Repair
{
    public class RepairDto
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public RepairStatus Status { get; set; } = RepairStatus.Pending;

        public decimal Cost { get; set; }

        public long PropertyId { get; set; }

        public string? OwnerName { get; set; }

        public string? OwnerSurname { get; set; }

        public string? PropertyAddress { get; set; }

        public string? E9 { get; set; }
    }
}
