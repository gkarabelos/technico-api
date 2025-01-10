using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Models;

namespace RetailApp.Interfaces;

public interface IOwnerRepository : IRepository<Owner>
{
    Task<bool> ExistsByVatNumberAsync(string vatNumber);
    Task<bool> IsVatNumberUniqueAsync(string vatNumber, long excludedId);

}    
