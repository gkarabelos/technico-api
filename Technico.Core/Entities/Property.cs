using Technico.Core.Enums;

namespace Technico.Core.Entities
{
    public class Property
    {
        public long Id { get; set; }

        public string PropertyId { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int YearOfConstruction { get; set; }

        public PropertyType Type { get; set; }

        public long OwnerId { get; set; }

        public virtual Owner Owner { get; set; } = null!;

        public virtual ICollection<Repair> Repairs { get; set; } = new List<Repair>();
    }
}
