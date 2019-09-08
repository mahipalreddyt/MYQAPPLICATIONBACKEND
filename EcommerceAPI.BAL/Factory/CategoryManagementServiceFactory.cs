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
    public class CategoryManagementServiceFactory : ICategoryManagementServiceFactory, IDisposable
    {
        public readonly CategoryMgmtRepository _categoryMgmtRepository;
        public CategoryManagementServiceFactory()
        {
            _categoryMgmtRepository = new CategoryMgmtRepository();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public ICategoryManagementService GetCategoryManagementService()
        {
            return new CategoryManagementService();
        }
    }
}
