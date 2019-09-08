using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EcommerceAPI.BAL.Interfaces;
using EcommerceAPI.BAL.Factory;
using EcommerceAPI.BAL;
using EcommerceAPI.Framework;
using EcommerceAPI.Framework.DTO;

using EcommerceAPI.Framework.DTO.Entity;
using EcommerceAPI.DAL.Context;
using EcommerceAPI.Framework.Utilities;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using System.Data.SqlClient;
using EcommerceAPI.Framework.DTO.RequestObjects;

namespace EcommerceAPI.Controllers
{
    public class CategoryManagementAPIController : ApiController
    {

        public readonly ICategoryManagementService _categoryManagementService;

        public CategoryManagementAPIController()
        {   
            CategoryManagementServiceFactory cmsFactory = new CategoryManagementServiceFactory();
            _categoryManagementService = cmsFactory.GetCategoryManagementService();
        }

        [HttpGet]
        public HttpResponseMessage GetCategoryHomeDrop()
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@countryId", "0") };

                var CategoryDrop = _categoryManagementService.GetCategoryDropHome(StoredProceduresList.GetCatListHome,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<List<CategoryDropHomeResponse>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage GetServiceCategories(CountryListRequest cr)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@CountryId", cr.CountryId) };

                var CategoryDrop = _categoryManagementService.GetServiceCategory(StoredProceduresList.GetServiceCategory,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<List<ServiceCategory>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage GetServiceSubCategories(SubCategoryListRequest slrs)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@CategoryId", slrs.CategoryId) };

                var CategoryDrop = _categoryManagementService.GetServiceSubCategories(StoredProceduresList.GetServiceSubCategory,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<List<ServiceSubCategory>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage GetSubcategoriesByCategory(SubCategoryListRequest request)
        {
            try
            {
                
                var CategoryDrop = _categoryManagementService.GetSubCategories(request);
                return
                    Request.CreateResponse<ApiResponse<List<Category>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetCountries()
        {
            try
            {
                //SqlParameter[] parameters = { new SqlParameter("@CategoryId", CategoryId) };

                var CategoryDrop = _categoryManagementService.GetCountriesMasters(StoredProceduresList.GetCountiesList,
                    System.Data.CommandType.StoredProcedure, null);
                return
                    Request.CreateResponse<ApiResponse<List<CountryMaster>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        public HttpResponseMessage GetStates(int CountryId)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@CountryId", CountryId) };

                var CategoryDrop = _categoryManagementService.GetStatesMasters(StoredProceduresList.GetStatesList,
                    System.Data.CommandType.StoredProcedure,parameters);
                return
                    Request.CreateResponse<ApiResponse<List<StateMaster>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }



        [HttpGet]
        public HttpResponseMessage GetCities(int StateId)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@StateId", StateId) };

                var CategoryDrop = _categoryManagementService.GetCityMasters(StoredProceduresList.GetCitieList,
                    System.Data.CommandType.StoredProcedure, parameters);
                return
                    Request.CreateResponse<ApiResponse<List<CityMaster>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        public HttpResponseMessage GetOpeningDays()
        {
            try
            {
                //SqlParameter[] parameters = { new SqlParameter("@StateId", StateId) };

                var CategoryDrop = _categoryManagementService.GetOpeningDays(StoredProceduresList.GetOpeningDays,
                    System.Data.CommandType.StoredProcedure, null);
                return
                    Request.CreateResponse<ApiResponse<List<OpeningDays>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        public HttpResponseMessage AdTypeMaster()
        {
            try
            {
                //SqlParameter[] parameters = { new SqlParameter("@StateId", StateId) };

                var CategoryDrop = _categoryManagementService.GetAddTypes(StoredProceduresList.GetAddTypes,
                    System.Data.CommandType.StoredProcedure, null);
                return
                    Request.CreateResponse<ApiResponse<List<AddTypeMaster>>>(HttpStatusCode.OK, CategoryDrop);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }


    }
}
