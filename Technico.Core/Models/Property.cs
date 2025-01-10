using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Enums;

namespace RetailApp.Models;

public class Property 
{
    public long Id { get; set; }
    public string E9 { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Year { get; set; }
    public  PropertyType Type { get; set; }
    public bool IsActive { get; set; } = true;
    public long OwnerId {  get; set; }
    public virtual Owner owner { get; set; } 



}
