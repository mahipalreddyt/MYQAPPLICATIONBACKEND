using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.Entity
{
    public class OpeningDays
    {
        [Key]
        public int OpeningId { get; set; }

        public string DayTime { get; set; }

        public bool? IsDeleted { get; set; }

        public int? SeqNo { get; set; }
    }
}
