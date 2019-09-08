using EcommerceAPI.BAL.Factory;
using EcommerceAPI.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceAPI.Controllers
{
    public class ProductManagementAPIController : ApiController
    {
        public readonly IYPProductManagementService _productManagementService;


        public ProductManagementAPIController()
        {
            
        }


        
    }
}
