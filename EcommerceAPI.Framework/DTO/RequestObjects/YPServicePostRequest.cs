using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.DTO.RequestObjects
{
    public class YPServicePostRequest
    {
        public int ServiceAdMasterId { get; set; }

        public string AdTitle { get; set; }

        public string AboutTheCompany { get; set; }

        public int? PostedBy { get; set; }

        public DateTime? PostedOn { get; set; }

        public int? AdOwner { get; set; }

        public int? LastmodifiedBy { get; set; }

        public int? LastmodifiedOn { get; set; }

        public int? AddTypeId { get; set; }

        public int? CategoryId { get; set; }

        public int? SubcategoryId { get; set; }

        public string CurrentStatus { get; set; }

        public int? PriorityNumber { get; set; }

        public DateTime? EffectiveDateTo { get; set; }

        public bool? IsDeleted { get; set; }

        public int? CityId { get; set; }
        public string OtherCity { get; set; }

        public string Location { get; set; }

        public string ContactNumber { get; set; }

        public string EmailId { get; set; }

        public bool? IsContactDetailsShown { get; set; }

        public int? ViewCount { get; set; }

        public string PageUrl { get; set; }

        public string ServicesProvided { get; set; }

        public string FoundedYear { get; set; }

        public string NoOfEmployees { get; set; }

        public string WorkingDays { get; set; }

        public string BusinessAddress { get; set; }

        public int? OpeningDayId { get; set; }

        public string FaceBookLink { get; set; }

        public string googlePlusLink { get; set; }

        public string twitterLink { get; set; }

        public string googleMapLink { get; set; }

        public string TSDegreeView { get; set; }

        public string ContactPerson { get; set; }

        public decimal? CurrentRating { get; set; }

        public string otherImages { get; set; }

        public string mainImage { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
    }
}
