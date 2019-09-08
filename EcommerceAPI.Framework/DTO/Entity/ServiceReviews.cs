using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class ServiceReviews
    {
        [Key]
        public int ReviewId { get; set; }

        public int? ServiceAdMasterId { get; set; }

        public int? ReviewBy { get; set; }

        public string ReviewText { get; set; }

        public DateTime? ReviewOn { get; set; }

        public bool? IsDeleted { get; set; }

        public decimal? Rating { get; set; }

    }
}
