using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technico.Core.DTOs
{
    public class ResponseApi<T>
    {
        public int StatusCode { get; set; }
        public string Description { get; set; } = string.Empty;
        public T? Value { get; set; }
    }
}
