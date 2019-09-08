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
    public class UserManagementServiceFactory : IUserManagementServiceFactory, IDisposable
    {
        public readonly UserManagementRepository _userManagementRepository;
        public UserManagementServiceFactory()
        {
            _userManagementRepository = new UserManagementRepository();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public IUserManagementService GetUserManagementService()
        {
            return new UserManagementService();
        }

    }
}
