using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class ServiceImages
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageUrl { get; set; }

        public string ImageType { get; set; }

        public bool? IsDeleted { get; set; }

        public int? ServiceAdMasterId { get; set; }
    }
}
