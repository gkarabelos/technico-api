

namespace Technico.Core.DTOs.Owner
{
    public class UpdateOwnerDto
    {
        public string VatNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
