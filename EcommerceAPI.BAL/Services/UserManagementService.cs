using EcommerceAPI.BAL.Interfaces;
using EcommerceAPI.DAL.Repositories;
using EcommerceAPI.Framework.DTO;
using EcommerceAPI.Framework.DTO.Entity;
using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using EcommerceAPI.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManagementRepository _userManagmentRepository;

        public UserManagementService()
        {
            _userManagmentRepository = new UserManagementRepository();
        }

        public ApiResponse<ProcessResponse> EmailAvailableCheck(string emailId)
        {
            ProcessResponse ps = new ProcessResponse();
            Customer customer = new Customer();
            var pwPredicate = PredicateBuilder.True<Customer>();
            pwPredicate.And(b => b.Email.Trim().Equals(emailId.Trim()));
            pwPredicate.And(b => b.Deleted == false);
            pwPredicate.And(b => b.Active == true);
            //customer = _userManagmentRepository.EmailAvailableCheck(pwPredicate);
            customer = _userManagmentRepository.EmailAvailableCheck(c => c.Email.Equals(emailId) && c.Deleted == false && c.Active == true);
            if (customer != null)
            {
                ps.StatusCode = 0;
                ps.Message = "Emaild Not available";
            }
            else
            {
                ps.StatusCode = 1;
                ps.Message = "Emailid avaialable";
            }

            return Transform.ConvertResultToApiResonse(ps);

        }

        public ApiResponse<LoginResponse> LoginCheck(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            
            if (loginRequest != null)
            {
                Customer c = new Customer();
                //var predicate = PredicateBuilder.True<Customer>();
                //predicate.And(a => c.Active == true);
                //predicate.And(b => b.Deleted == false);
                //predicate.And(b => b.Email == loginRequest.emailId);
                //c = _userManagmentRepository.GetCustomerByEmail(predicate);
                c = _userManagmentRepository.GetCustomerByEmail(b => b.Email.Equals(loginRequest.emailId) && 
                b.Deleted == false && b.Active == true);
                if (c != null)
                {
                    CustomerPassword cp = new CustomerPassword();
                    var pwPredicate = PredicateBuilder.True<CustomerPassword>();
                    pwPredicate.And(b => b.CustomerId == c.Id);
                    cp = _userManagmentRepository.GetPassword(pwPredicate);
                    if (cp != null)
                    {
                        if (cp.Password.Equals(loginRequest.pword))
                        {
                            loginResponse.Email = c.Email;
                            loginResponse.CustomerType = c.CustomerType;
                            loginResponse.Id = c.Id;
                            loginResponse.Message = "Login success";
                            loginResponse.SuccessCode = 1;
                            loginResponse.Username = c.Username;
                        }
                        else
                        {
                            loginResponse.Email = "";
                            loginResponse.CustomerType = "";
                            loginResponse.Id = 0;
                            loginResponse.Message = "Password mismatch";
                            loginResponse.SuccessCode = 0;
                            loginResponse.Username = "";
                        }
                    }
                    else
                    {
                        loginResponse.Email = "";
                        loginResponse.CustomerType = "";
                        loginResponse.Id = 0;
                        loginResponse.Message = "Password mismatch";
                        loginResponse.SuccessCode = 0;
                        loginResponse.Username = "";
                    }
                }
                else
                {
                    loginResponse.Email = "";
                    loginResponse.CustomerType = "";
                    loginResponse.Id = 0;
                    loginResponse.Message = "Emailid is not registerd, please register.";
                    loginResponse.SuccessCode = 0;
                    loginResponse.Username = "";
                }
            }
            else
            {
                loginResponse.Email = "";
                loginResponse.CustomerType = "";
                loginResponse.Id = 0;
                loginResponse.Message = "Emailid is mandatory";
                loginResponse.SuccessCode = 0;
                loginResponse.Username = "";
            }

            




            return Transform.ConvertResultToApiResonse(loginResponse);
        }


        public ApiResponse<ProcessResponse> RegisterUser(CustomerSaveRequest customerSave)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {
                Customer c = new Customer();
              
                c.Active = true;
                c.AdminComment = customerSave.AdminComment;
                c.AffiliateId = customerSave.AffiliateId;
                c.BillingAddress_Id = 0;
                c.CannotLoginUntilDateUtc = null;
                c.CreatedOnUtc = DateTime.Now;
                c.CustomerType = customerSave.CustomerType;
                c.Deleted = false;
                c.Email = customerSave.Email;
                c.EmailToRevalidate = customerSave.EmailToRevalidate;
                c.FailedLoginAttempts = 0;
                c.HasShoppingCartItems = false;
                c.IsSystemAccount = false;
                c.IsTaxExempt = false;
                c.LastActivityDateUtc = DateTime.Now;
                c.RegisteredInStoreId = 0;
                c.RequireReLogin = false;
                c.ShippingAddress_Id = 0;
                c.SystemName = null;
                c.Username = customerSave.FirstName + " " + customerSave.LastName;
                c.VendorId = 0;
                c = _userManagmentRepository.RegisterCustomer(c);
                if (c.Id > 0)
                {
                    CustomerAddresses ca = new CustomerAddresses();
                    CustomerPassword cp = new CustomerPassword();
                    Address add = new Address();
                    cp.CustomerId = c.Id;
                    cp.Password = customerSave.password;
                    cp.CreatedOnUtc = DateTime.Now;
                    ps = _userManagmentRepository.SavePassword(cp);

                    add.Address1 = customerSave.Address1;
                    add.Address2 = customerSave.Address2;
                    add.City = customerSave.City;
                    add.Company = customerSave.Company;
                    add.CountryId = customerSave.CountryId;
                    add.CreatedOnUtc = DateTime.Now;
                    add.Email = customerSave.Email;
                    add.FaxNumber = customerSave.FaxNumber;
                    add.FirstName = customerSave.FirstName;
                    add.LastName = customerSave.LastName;
                    add.PhoneNumber = customerSave.PhoneNumber;
                    add.StateProvinceId = customerSave.StateProvinceId;
                    add.ZipPostalCode = customerSave.ZipPostalCode;
                    add = _userManagmentRepository.SaveAddress(add);

                    ca.Address_Id = add.Id;
                    ca.Customer_Id = c.Id;
                    ps = _userManagmentRepository.SaveCustomerAddress(ca);
                    ps.CurrentId = c.Id;
                }
            }
            catch (Exception ex)
            {
                ps.Message = "Failed to save " + ex.ToString();
                ps.StatusCode = 0;
                ps.CurrentId = 0;
            }
            return Transform.ConvertResultToApiResonse(ps);

        }
    }
}
