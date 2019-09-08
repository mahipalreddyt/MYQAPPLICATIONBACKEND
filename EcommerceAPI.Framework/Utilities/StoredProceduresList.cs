using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Framework.Utilities
{
    public static class StoredProceduresList
    {
        public static string GetCatListHome = "Usp_GetCatListHomeDrop";
        public static string GetServiceCategory = "Usp_GetServiceCategories";
        public static string GetServiceSubCategory = "Usp_GetServiceSubCategories"; // send CategoryId
        public static string GetOpeningDays = "Usp_GetOpeningDays";
        public static string GetAddTypes = "Usp_GetAdTypes";
        public static string GetCountiesList = "Usp_GetCountriesList";
        public static string GetStatesList = "Usp_GetStatesList"; // send CountryId
        public static string GetCitieList = "Usp_GetCitiesList"; // send StateId
        public static string GetYPAdById = "Usp_GetYPAdById"; // send Id
        public static string GetYPAdByCountry = "Usp_GetYPAdsByCountry"; // send CountryId
        public static string GetYPAdByCategory = "Usp_GetYPAdsByCategory"; // CategoryId
        public static string GetYPAdBySubCategory = "Usp_GetYPAdsBySubCategory"; // SubCategoryId


    }
}
