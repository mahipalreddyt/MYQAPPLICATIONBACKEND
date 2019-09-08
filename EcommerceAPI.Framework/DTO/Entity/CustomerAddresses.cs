using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class CustomerAddresses
    {
        [Key]
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        
        public int Address_Id { get; set; }
    }
}
