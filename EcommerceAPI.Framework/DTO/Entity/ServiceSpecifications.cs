using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class ServiceSpecifications
    {
        [Key]
        public int SpecId { get; set; }

        public string SpecName { get; set; }

        public int? DataType { get; set; }

        public int? ControlType { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }

        public int? RangeValue { get; set; }

        public bool? IsDeleted { get; set; }

        public int? SubCategoryId { get; set; }

        public string SpecType { get; set; }
    }
}
