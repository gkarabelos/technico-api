using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Enums;

namespace RetailApp.Models;

public class Repair
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } = string.Empty;

    public RepairStatus Status { get; set; } = RepairStatus.Pending;
    public decimal Cost { get; set; }
    public string? Description { get; set; }= string.Empty;
    public long PropertyId { get; set; }
    public virtual Property? Property { get; set; } // Navigation property


}
