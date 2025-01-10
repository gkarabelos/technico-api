using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Dtos.Owner;
using RetailApp.Dtos.Repair;

namespace RetailApp.Dtos.Property;

public   class PropertyDto
{
    public long Id { get; set; }

    public string E9 { get; set; } = string.Empty;

    public string Address { get; set; } = null!;

    public int Year { get; set; }

    public string Type { get; set; }  
    public OwnerDto Owner { get; set; }

    public List<RepairDto> Repairs { get; set; }// ????


}
