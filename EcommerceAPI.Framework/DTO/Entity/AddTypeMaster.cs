using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class AddTypeMaster
    {
        [Key]
        public int AddTypeId { get; set; }

        public string AddTypeName { get; set; }

        public bool? IsDeleted { get; set; }

        public decimal? Price { get; set; }

        public int? ValidFor { get; set; }

        public int? countryId { get; set; }

    }
}
