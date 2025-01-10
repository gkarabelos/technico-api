using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Dtos.Property;
using RetailApp.Enums;

namespace RetailApp.Dtos.Owner;

public class OwnerDto
{
    public long Id { get; set; }

    public string VatNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public UserType Type { get; set; }

    public List<PropertyDto> Properties { get; set; }


}
