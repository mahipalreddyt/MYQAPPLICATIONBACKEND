using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.RequestObjects
{
    public class LoginRequest
    {
        public string emailId { get; set; }
        public string pword { get; set; }
    }
}
