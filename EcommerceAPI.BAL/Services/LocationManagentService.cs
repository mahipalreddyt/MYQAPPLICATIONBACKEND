using EcommerceAPI.BAL.Interfaces;
using EcommerceAPI.DAL.Repositories;
using EcommerceAPI.Framework.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.BAL.Services
{
    public class LocationManagentService : ILocationManagentService
    {
        private readonly LocationManagmentRepository _locationManagementRepository;
        public LocationManagentService()
        {
            _locationManagementRepository = new LocationManagmentRepository();
        }

        public int AddCity(CityMaster cm)
        {
            cm = _locationManagementRepository.AddNewCity(cm);
            return cm.CityId;
        }

    }
}
