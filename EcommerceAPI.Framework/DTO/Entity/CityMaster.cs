using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class CityMaster
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int? StateId { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string PostalCode { get; set; }

    }
}
