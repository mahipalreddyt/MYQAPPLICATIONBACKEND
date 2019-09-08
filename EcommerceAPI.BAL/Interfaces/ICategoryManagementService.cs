using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.Entity;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Interfaces
{
    public interface ICategoryManagementService 
    {
        ApiResponse<List<CategoryDropHomeResponse>> GetCategoryDropHome(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);


        ApiResponse<List<ServiceCategory>> GetServiceCategory(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);

        ApiResponse<List<ServiceSubCategory>> GetServiceSubCategories(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);
        ApiResponse<List<StateMaster>> GetStatesMasters(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);

        ApiResponse<List<CountryMaster>> GetCountriesMasters(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);


        ApiResponse<List<CityMaster>> GetCityMasters(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);

        ApiResponse<List<AddTypeMaster>> GetAddTypes(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);

        ApiResponse<List<OpeningDays>> GetOpeningDays(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters);

        ApiResponse<List<Category>> GetSubCategories(SubCategoryListRequest request);
    }
}
