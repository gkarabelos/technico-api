using Technico.Core.Enums;

namespace Technico.Core.Entities
{
    public class Owner
    {
        public long Id { get; set; }

        public string VatNumber { get; set; } = null!;
        
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email {  get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public UserType Type { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
