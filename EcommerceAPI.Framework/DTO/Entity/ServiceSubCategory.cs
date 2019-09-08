using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class ServiceSubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public string SubCategoryCode { get; set; }

        public string SubCategoryImage { get; set; }

        public bool? IsDeleted { get; set; }

        public int? SequenceNumber { get; set; }

        public int? CategoryId { get; set; }
    }
}
