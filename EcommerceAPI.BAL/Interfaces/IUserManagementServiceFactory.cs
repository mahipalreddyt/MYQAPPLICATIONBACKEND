using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Interfaces
{
    public interface IUserManagementServiceFactory
    {
        IUserManagementService GetUserManagementService();
    }
}
