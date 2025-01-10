using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RetailApp.Enums;

namespace RetailApp.Models;

public class Owner 
{

        public long Id { get; set; }
        public string VATNumber { get; set; }= string.Empty;
        public string Name { get; set; } =string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string  Email { get; set; } = string.Empty; // Used as Username
        public string Password { get; set; } = string.Empty;
        public  UserType Type  { get; set; }
        public virtual List<Property> Properties { get; set; } = [];

}


