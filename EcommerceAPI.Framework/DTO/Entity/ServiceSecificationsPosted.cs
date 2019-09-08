using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class ServiceSecificationsPosted
    {
        [Key]
        public int SSPId { get; set; }

        public int? SpecId { get; set; }

        public string ValuePosted { get; set; }

        public bool? IsDeleted { get; set; }

        public int? ServiceAdMasterId { get; set; }
    }
}
