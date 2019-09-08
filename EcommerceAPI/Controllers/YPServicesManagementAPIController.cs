using EcommerceAPI.BAL.Factory;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using System.Data.SqlClient;
using EcommerceAPI.Framework.Utilities;

namespace EcommerceAPI.Controllers
{
    public class YPServicesManagementAPIController : ApiController
    {
        public readonly IYPProductManagementService _productManagementService;

        public YPServicesManagementAPIController()
        {
            YPProductManagementServiceFactory pmsFactry = new YPProductManagementServiceFactory();
            _productManagementService = pmsFactry.GetProductManagementService();
        }

        [HttpPost]
        public HttpResponseMessage SaveYPAd(YPServicePostRequest yp)
        {
            try
            {
                var result = _productManagementService.PostProduct(yp);
                return Request.CreateResponse<ApiResponse<ProcessResponse>>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpPost]
        public HttpResponseMessage GetYPAdById(int Id)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Id", Id) };

                var CategoryDrop = _productManagementService.GetYPAdById(StoredProceduresList.GetYPAdById,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<USPGetYPAdByIdResponse>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpPost]
        public HttpResponseMessage GetYPByCategory(int CategoryId)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@CategoryId", CategoryId) };

                var CategoryDrop = _productManagementService.GetYPByCategory(StoredProceduresList.GetYPAdByCategory,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<List<USPGetYPAdsByCategoryResponse>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }

        }
        [HttpPost]
        public HttpResponseMessage GetYPByCountry(int CountryId)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@CountryId", CountryId) };

                var CategoryDrop = _productManagementService.GetYPByCountry(StoredProceduresList.GetYPAdByCountry,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<List<USPGetYPAdsByCountryResponse>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpPost]
        public HttpResponseMessage GetYPBySubCategory(int SubCategoryId)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@SubCategoryId", SubCategoryId) };

                var CategoryDrop = _productManagementService.GetYPBySubCategory(StoredProceduresList.GetYPAdBySubCategory,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<List<USPGetYPAdsBySubCategoryResponse>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }

        }
    }
}
