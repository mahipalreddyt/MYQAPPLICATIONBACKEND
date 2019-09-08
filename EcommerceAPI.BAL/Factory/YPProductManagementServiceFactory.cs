using EcommerceAPI.BAL.Interfaces;
using EcommerceAPI.BAL.Services;
using EcommerceAPI.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Factory
{
    public class YPProductManagementServiceFactory : IYPProductManagementServiceFactory, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public readonly YPProductManagementRepository  _productManagementRepository;

        public YPProductManagementServiceFactory()
        {
            _productManagementRepository = new  YPProductManagementRepository();
        }
        
        public IYPProductManagementService GetProductManagementService()
        {
            return new YPProductManagementService();
        }
    }
}
