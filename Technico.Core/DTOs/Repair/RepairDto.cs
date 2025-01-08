

namespace Technico.Core.DTOs.Repair
{
    public class RepairDto
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public string Status { get; set; } = "Pending";

        public decimal Cost { get; set; }

        public long PropertyId { get; set; }
    }
}
