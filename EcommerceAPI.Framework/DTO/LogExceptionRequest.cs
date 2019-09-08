using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO
{
    public class LogExceptionRequest
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Severity { get; set; } = 1;

    }
}
