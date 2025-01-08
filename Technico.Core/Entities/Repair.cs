using Technico.Core.Enums;

namespace Technico.Core.Entities
{
    public class Repair
    {
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public RepairStatus Status { get; set; } = RepairStatus.Pending;

        public decimal Cost { get; set; }

        public long PropertyId { get; set; }

        public virtual Property Property { get; set; } = null!;
    }
}
