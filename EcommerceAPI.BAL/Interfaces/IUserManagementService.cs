using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Interfaces
{
    public interface IUserManagementService
    {
        ApiResponse<LoginResponse> LoginCheck(LoginRequest loginRequest);
        ApiResponse<ProcessResponse> RegisterUser(CustomerSaveRequest customerSave);
        ApiResponse<ProcessResponse> EmailAvailableCheck(string emailId);
    }
}
