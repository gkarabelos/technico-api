using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Enums;

namespace RetailApp.Dtos.Property;

public class CreatePropertyDto
{
    public string E9 { get; set; } = string.Empty;
    public string PropertyId { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int YearOfConstruction { get; set; }

    public PropertyType Type { get; set; }

    public long OwnerId { get; set; }

}
