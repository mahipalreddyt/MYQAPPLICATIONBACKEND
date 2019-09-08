using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO
{
    public class ApiResponse <T>
    {
        public T Response { get; set; }
        public bool Succeded { get; set; } = false;
        public IEnumerable<string> Errors { get; set; }

    }
}
