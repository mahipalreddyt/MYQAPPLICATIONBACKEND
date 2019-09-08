using EcommerceAPI.Framework.DTO.RequestObjects;
using EcommerceAPI.Framework.DTO.ResponseObjects;
using EcommerceAPI.Framework.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EcommerceAPI.Framework.DTO;

namespace EcommerceAPI.DAL.Repositories
{
    public class UserManagementRepository
    {

        public Customer GetCustomerByEmail(Expression<Func<Customer, bool>> predicate)
        {
            GenericRepository<Customer> GR = new GenericRepository<Customer>();
            Customer c = (Customer)GR.FindOneRecord(predicate);
            return c;
        }

        public CustomerPassword GetPassword(Expression<Func<CustomerPassword, bool>> predicate)
        {
            GenericRepository<CustomerPassword> GR = new GenericRepository<CustomerPassword>();
            CustomerPassword cp = (CustomerPassword)GR.FindOneRecord(predicate);
            return cp;
        }

        public Customer EmailAvailableCheck(Expression<Func<Customer, bool>> predicate)
        {
            GenericRepository<Customer> GR = new GenericRepository<Customer>();
            Customer cp = (Customer)GR.FindOneRecord(predicate);
            return cp;
        }


        public Customer RegisterCustomer(Customer c)
        {
            
            try
            {
                GenericRepository<Customer> GR = new GenericRepository<Customer>();
                c= GR.SaveReturnId(c);
            
            }
            catch (Exception ex)
            {
                
            }
            return c;            
        }

        public Address SaveAddress(Address ad)
        {
            try
            {
                GenericRepository<Address> GR = new GenericRepository<Address>();
                ad = GR.SaveReturnId(ad);

            }
            catch (Exception ex)
            {
            }
            return ad;
        }

        public ProcessResponse SavePassword(CustomerPassword ca)
        {
            ProcessResponse pr = new ProcessResponse();
            try
            {
                GenericRepository<CustomerPassword> GR = new GenericRepository<CustomerPassword>();
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

        public ProcessResponse SaveCustomerAddress(CustomerAddresses ca)
        {
            ProcessResponse pr = new ProcessResponse();
            try
            {
                GenericRepository<CustomerAddresses> GR = new GenericRepository<CustomerAddresses>();
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
    }
}
