using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.Entity;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using EcommerceAPI.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.DAL.Repositories
{
    public class YPProductManagementRepository  
    {
        public ServiceAdMaster SaveProduct(ServiceAdMaster c)
        {
            try
            {
                GenericRepository<ServiceAdMaster> GR = new GenericRepository<ServiceAdMaster>();
                c = GR.SaveReturnId(c);
            }
            catch (Exception ex)
            {

            }
            return c;
        }

        public ProcessResponse SaveImage(ServiceImages ca)
        {
            ProcessResponse pr = new ProcessResponse();
            try
            {
                GenericRepository<ServiceImages> GR = new GenericRepository<ServiceImages>();
                GR.Save(ca);
                pr.Message = "Saved successfully";
                pr.StatusCode = 1;

            }
            catch (Exception ex)
            {
                pr.Message = "Failed to save : " + ex;
                pr.StatusCode = 0;
            }
            return pr;
        }


        public ApiResponse<USPGetYPAdByIdResponse> GetYPAdById(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<USPGetYPAdByIdResponse> GR = new GenericRepository<USPGetYPAdByIdResponse>();
                USPGetYPAdByIdResponse response = (USPGetYPAdByIdResponse)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<USPGetYPAdByIdResponse>(
                    new USPGetYPAdByIdResponse(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public ApiResponse<List<USPGetYPAdsByCategoryResponse>> GetYPAdByCategory(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<USPGetYPAdsByCategoryResponse> GR = new GenericRepository<USPGetYPAdsByCategoryResponse>();
                List<USPGetYPAdsByCategoryResponse> response = (List<USPGetYPAdsByCategoryResponse>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<USPGetYPAdsByCategoryResponse>>(
                    new List<USPGetYPAdsByCategoryResponse>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public ApiResponse<List<USPGetYPAdsByCountryResponse>> GetYPadsByCountry(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<USPGetYPAdsByCountryResponse> GR = new GenericRepository<USPGetYPAdsByCountryResponse>();
                List<USPGetYPAdsByCountryResponse> response = (List<USPGetYPAdsByCountryResponse>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<USPGetYPAdsByCountryResponse>>(
                    new List<USPGetYPAdsByCountryResponse>(),
                    new List<string>() { "DB operation failed", ex.Message }
                    );
            }
        }

        public ApiResponse<List<USPGetYPAdsBySubCategoryResponse>> GetYPadsBySubCategory(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {
            try
            {
                GenericRepository<List<USPGetYPAdsBySubCategoryResponse>> GR = new GenericRepository<List<USPGetYPAdsBySubCategoryResponse>>();
                List<USPGetYPAdsBySubCategoryResponse> response = (List<USPGetYPAdsBySubCategoryResponse>)GR.ExecuteQuery(sqlQuery, commandType, parameters);
                return Transform.ConvertResultToApiResonse(response);
            }
            catch (Exception ex)
            {
                LogExceptionMeassage(ex);
                return Transform.GetErrorResponse<List<USPGetYPAdsBySubCategoryResponse>>(
                    new List<USPGetYPAdsBySubCategoryResponse>(),
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

    }
}
