using EcommerceAPI.BAL.Interfaces;
using EcommerceAPI.DAL.Repositories;
using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.Entity;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using EcommerceAPI.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Services
{
    public class YPProductManagementService : IYPProductManagementService
    {
        private readonly YPProductManagementRepository _productManagementRepository;
        ILocationManagentService _locationManagentService;
        public  YPProductManagementService()
        {
            _productManagementRepository = new YPProductManagementRepository();
            _locationManagentService = new LocationManagentService();
        }

        public ApiResponse<ProcessResponse> PostProduct(YPServicePostRequest ypSave)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {
                ServiceAdMaster sm = new ServiceAdMaster();
                sm.AboutTheCompany = ypSave.AboutTheCompany;
                sm.AddTypeId = ypSave.AddTypeId;
                sm.AdOwner = ypSave.AdOwner;
                sm.AdTitle = ypSave.AdTitle;
                sm.BusinessAddress = ypSave.BusinessAddress;
                sm.CategoryId = ypSave.CategoryId;
                // check if city is new 
                if (!string.IsNullOrEmpty(ypSave.OtherCity))
                {
                    // save new city and get the id
                    CityMaster cm = new CityMaster();
                    cm.CityName = ypSave.OtherCity;
                    cm.StateId = ypSave.StateId;
                    int CityId = _locationManagentService.AddCity(cm);
                    sm.CityId = CityId;
                }
                else
                {
                    sm.CityId = ypSave.CityId;
                }
                
                sm.ContactNumber = ypSave.ContactNumber;
                sm.ContactPerson = ypSave.ContactPerson;
                sm.CurrentRating = 0;
                sm.CurrentStatus = ypSave.CurrentStatus;
                sm.EffectiveDateTo = ypSave.EffectiveDateTo;
                sm.EmailId = ypSave.EmailId;
                sm.FaceBookLink = ypSave.FaceBookLink;
                sm.FoundedYear = ypSave.FoundedYear;
                sm.googleMapLink = ypSave.googleMapLink;
                sm.googlePlusLink = ypSave.googlePlusLink;
                sm.IsContactDetailsShown = ypSave.IsContactDetailsShown;
                sm.IsDeleted = ypSave.IsDeleted;
                sm.LastmodifiedBy = ypSave.LastmodifiedBy;
                sm.LastmodifiedOn = ypSave.LastmodifiedOn;
                sm.Location = ypSave.Location;
                sm.NoOfEmployees = ypSave.NoOfEmployees;
                sm.OpeningDayId = ypSave.OpeningDayId;
                sm.PostedBy = ypSave.PostedBy;
                sm.PostedOn = ypSave.PostedOn;
                sm.PriorityNumber = ypSave.PriorityNumber;
                sm.ServiceAdMasterId = ypSave.ServiceAdMasterId;
                sm.ServicesProvided = ypSave.ServicesProvided;
                sm.SubcategoryId = ypSave.SubcategoryId;
                sm.TSDegreeView = ypSave.TSDegreeView;
                sm.twitterLink = ypSave.twitterLink;
                sm.ViewCount = 0;
                sm.WorkingDays = sm.WorkingDays;
                sm = _productManagementRepository.SaveProduct(sm);


                if (!string.IsNullOrEmpty(ypSave.mainImage))
                {
                    ServiceImages im = new ServiceImages();
                    im.ImageType = "Main";
                    im.ImageUrl = ypSave.mainImage;
                    im.IsDeleted = false;
                    im.ServiceAdMasterId = sm.ServiceAdMasterId;
                    ps = _productManagementRepository.SaveImage(im);
                }

                if (!string.IsNullOrEmpty(ypSave.otherImages))
                {
                    List<string> fileNames = ypSave.otherImages.Split(',').ToList();
                    for (int i = 0; i < fileNames.Count; i++)
                    {
                        ServiceImages im = new ServiceImages();
                        im.ImageType = "Others";
                        im.ImageUrl = fileNames[i];
                        im.IsDeleted = false;
                        im.ServiceAdMasterId = sm.ServiceAdMasterId;

                        ps = _productManagementRepository.SaveImage(im);
                    }
                    
                }

            
            }
            catch (Exception ex)
            {
                ps.Message = "Failed to save " + ex.ToString();
                ps.StatusCode = 0;
            }
            return Transform.ConvertResultToApiResonse(ps);

        }


        public ApiResponse<USPGetYPAdByIdResponse> GetYPAdById(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {

            return _productManagementRepository.GetYPAdById(sqlQuery,commandType,parameters);
        }
        public ApiResponse<List<USPGetYPAdsByCategoryResponse>> GetYPByCategory(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {

            return _productManagementRepository.GetYPAdByCategory(sqlQuery, commandType, parameters);
        }
        public ApiResponse<List<USPGetYPAdsBySubCategoryResponse>> GetYPBySubCategory(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {

            return _productManagementRepository.GetYPadsBySubCategory(sqlQuery, commandType, parameters);
        }

        public ApiResponse<List<USPGetYPAdsByCountryResponse>> GetYPByCountry(string sqlQuery,
           CommandType commandType, SqlParameter[] parameters)
        {

            return _productManagementRepository.GetYPadsByCountry(sqlQuery, commandType, parameters);
        }
    }
}
