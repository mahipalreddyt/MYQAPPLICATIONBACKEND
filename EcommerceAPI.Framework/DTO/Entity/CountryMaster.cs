using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class CountryMaster
    {
        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public bool? IsActive { get; set; }

        public string CountryCode { get; set; }

        public string PhoneCode { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyNumber { get; set; }

        public string CurrencyHtmlcode { get; set; }
    }
}
