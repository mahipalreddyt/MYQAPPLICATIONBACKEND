using EcommerceAPI.BAL.Factory;
using EcommerceAPI.BAL.Interfaces;
using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceAPI.Controllers
{
    public class UserManagementAPIController : ApiController
    {
        public readonly IUserManagementService _userManagementService;

        public UserManagementAPIController()
        {
            UserManagementServiceFactory umsFactory = new UserManagementServiceFactory();
            _userManagementService = umsFactory.GetUserManagementService();
        }

        [HttpPost]
        public HttpResponseMessage LoginCheck(LoginRequest request)
        {
            try
            {
                var result = _userManagementService.LoginCheck(request);
                return Request.CreateResponse<ApiResponse<LoginResponse>>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpPost]
        public HttpResponseMessage RegisterUser(CustomerSaveRequest request)
        {
            try
            {
                var result = _userManagementService.RegisterUser(request);
                return Request.CreateResponse<ApiResponse<ProcessResponse>>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpPost]
        public HttpResponseMessage EmailAvailabilityCheck(LoginRequest request)
        {
            try
            {
                var result = _userManagementService.EmailAvailableCheck(request.emailId);
                return Request.CreateResponse<ApiResponse<ProcessResponse>>(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse<System.Exception>(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
