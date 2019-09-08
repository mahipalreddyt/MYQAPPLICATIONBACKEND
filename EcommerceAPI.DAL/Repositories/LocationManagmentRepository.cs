using EcommerceAPI.Framework.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.DAL.Repositories
{
    public class LocationManagmentRepository
    {
        public CityMaster AddNewCity(CityMaster c)
        {

            try
            {
                GenericRepository<CityMaster> GR = new GenericRepository<CityMaster>();
                c = GR.SaveReturnId(c);

            }
            catch (Exception ex)
            {

            }
            return c;
        }
    }
}
