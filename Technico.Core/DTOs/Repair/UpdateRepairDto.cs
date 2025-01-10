using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Enums;

namespace RetailApp.Dtos.Repair;

public class UpdateRepairDto
{
    public DateTime ScheduledDate { get; set; }
    public RepairStatus Status { get; set; }=RepairStatus.Pending;
    public decimal Cost { get; set; }
    public string? Description { get; set; } = string.Empty;
    public long PropertyId { get; set; }
}
