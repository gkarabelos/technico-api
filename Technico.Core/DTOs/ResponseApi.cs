using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Dtos;

public class ResponseApi<T>
{
    public int StatusCode { get; set; }
    public string description { get; set; } = string.Empty;
    public T? Value { get; set; }
}
