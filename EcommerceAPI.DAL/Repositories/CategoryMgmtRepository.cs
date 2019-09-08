using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EcommerceAPI.Framework.DTO;

using EcommerceAPI.Framework.DTO.Entity;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using EcommerceAPI.Framework.Utilities;
namespace EcommerceAPI.DAL.Repositories
{
    public class CategoryMgmtRepository
    {
        public ApiResponse<List<CategoryDropHomeResponse>> GetCategoryDropHome(string sqlQuery, CommandType commandtype, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<CategoryDropHomeResponse> GR = new GenericRepository<CategoryDropHomeResponse>();
                List<CategoryDropHomeResponse> response = (List<CategoryDropHomeResponse>)GR.ExecuteQuery(sqlQuery, commandtype, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<CategoryDropHomeResponse>>(
                    new List<CategoryDropHomeResponse>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public void LogExceptionMeassage(Exception ex)
        {
            try
            {
                LogExceptionRequest logExceptionRequest = new LogExceptionRequest();
                logExceptionRequest.Message = "DB operation failed" + " - " + ex.Message;
                logExceptionRequest.Error = ex.StackTrace;
                logExceptionRequest.Severity = 2;
                // log to db server table
            }
            catch
            {

            }
        }

        public ApiResponse<List<ServiceCategory>> GetServiceCategories(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<ServiceCategory> GR = new GenericRepository<ServiceCategory>();
                List<ServiceCategory> response = (List<ServiceCategory>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<ServiceCategory>>(
                    new List<ServiceCategory>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }


        public ApiResponse<List<ServiceSubCategory>> GetServiceSubCategories(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<ServiceSubCategory> GR = new GenericRepository<ServiceSubCategory>();
                List<ServiceSubCategory> response = (List<ServiceSubCategory>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<ServiceSubCategory>>(
                    new List<ServiceSubCategory>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public ApiResponse<List<AddTypeMaster>> GetAdTypes(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<AddTypeMaster> GR = new GenericRepository<AddTypeMaster>();
                List<AddTypeMaster> response = (List<AddTypeMaster>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<AddTypeMaster>>(
                    new List<AddTypeMaster>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public ApiResponse<List<OpeningDays>> GetOpeningDays(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            try
            { 
                GenericRepository<OpeningDays> GR = new GenericRepository<OpeningDays>();
                List<OpeningDays> response = (List<OpeningDays>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<OpeningDays>>(
                    new List<OpeningDays>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }


        public ApiResponse<List<CountryMaster>> GetCountries(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<CountryMaster> GR = new GenericRepository<CountryMaster>();
                List<CountryMaster> response = (List<CountryMaster>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<CountryMaster>>(
                    new List<CountryMaster>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public ApiResponse<List<CityMaster>> GetCities(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<CityMaster> GR = new GenericRepository<CityMaster>();
                List<CityMaster> response = (List<CityMaster>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<CityMaster>>(
                    new List<CityMaster>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public ApiResponse<List<StateMaster>> GetStates(string sqlQuery,
            CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<StateMaster> GR = new GenericRepository<StateMaster>();
                List<StateMaster> response = (List<StateMaster>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<StateMaster>>(
                    new List<StateMaster>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public List<Category> GetSubCategories(Expression<Func<Category, bool>> predicate)
        {
            GenericRepository<Category> GR = new GenericRepository<Category>();
            List<Category> cp = (List<Category>)GR.Find(predicate);
            return cp;
        }
    }
}
