using EcommerceAPI.Framework.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Interfaces
{
    public interface ILocationManagentService
    {
        int AddCity(CityMaster cm);
    }
}
