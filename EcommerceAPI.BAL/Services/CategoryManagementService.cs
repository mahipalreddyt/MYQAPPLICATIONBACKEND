using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceAPI.BAL.Interfaces;
using EcommerceAPI.DAL.Repositories;
using EcommerceAPI.Framework.DTO;

using System.Linq.Expressions;
using EcommerceAPI.Framework.DTO.Entity;

using EcommerceAPI.Framework.DTO.ResponseObjects;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.Utilities;

namespace EcommerceAPI.BAL.Services
{
    public class CategoryManagementService : ICategoryManagementService
    {
        private readonly CategoryMgmtRepository categoryMgmtRepository;

        public CategoryManagementService()
        {
            categoryMgmtRepository = new CategoryMgmtRepository();
        }
        public ApiResponse<List<CategoryDropHomeResponse>> GetCategoryDropHome(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)        
        {
            return categoryMgmtRepository.GetCategoryDropHome(sqlQuery, commandType, parameters);
        }

        public ApiResponse<List<ServiceCategory>> GetServiceCategory(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            return categoryMgmtRepository.GetServiceCategories(sqlQuery, commandType, parameters);
        }

        public ApiResponse<List<ServiceSubCategory>> GetServiceSubCategories(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            return categoryMgmtRepository.GetServiceSubCategories(sqlQuery, commandType, parameters);
        }


        public ApiResponse<List<CountryMaster>> GetCountriesMasters(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            return categoryMgmtRepository.GetCountries(sqlQuery, commandType, parameters);
        }
        public ApiResponse<List<StateMaster>> GetStatesMasters(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            return categoryMgmtRepository.GetStates(sqlQuery, commandType, parameters);
        }


        public ApiResponse<List<CityMaster>> GetCityMasters(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            return categoryMgmtRepository.GetCities(sqlQuery, commandType, parameters);
        }
        public ApiResponse<List<AddTypeMaster>> GetAddTypes(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            return categoryMgmtRepository.GetAdTypes(sqlQuery, commandType, parameters);
        }
        public ApiResponse<List<OpeningDays>> GetOpeningDays(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            return categoryMgmtRepository.GetOpeningDays(sqlQuery, commandType, parameters);
        }
        public ApiResponse<List<Category>> GetSubCategories(SubCategoryListRequest request)
        {
            List<Category> myList = new List<Category>();
            
            myList = categoryMgmtRepository.GetSubCategories(m=>m.Id != 0 && m.ParentCategoryId == request.CategoryId && m.Deleted == false);
            return Transform.ConvertResultToApiResonse(myList);
        }
    }
}
