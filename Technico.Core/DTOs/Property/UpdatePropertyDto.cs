using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Enums;

namespace RetailApp.Dtos.Property;

public class UpdatePropertyDto
{
    public string E9 { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Year { get; set; }
    public PropertyType Type { get; set; } 
    public int OwnerId { get; set; } // Editable (if you allow changing the owner)
}
