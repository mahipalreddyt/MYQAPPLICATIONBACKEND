using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EcommerceAPI.App_Start;
namespace EcommerceAPI.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }

    }
}