using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Interfaces
{
    public interface IYPProductManagementService
    {
        ApiResponse<ProcessResponse> PostProduct(YPServicePostRequest ypSave);
        ApiResponse<USPGetYPAdByIdResponse> GetYPAdById(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters);
        ApiResponse<List<USPGetYPAdsByCategoryResponse>> GetYPByCategory(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters);
        ApiResponse<List<USPGetYPAdsBySubCategoryResponse>> GetYPBySubCategory(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters);
        ApiResponse<List<USPGetYPAdsByCountryResponse>> GetYPByCountry(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters);
    }
}
