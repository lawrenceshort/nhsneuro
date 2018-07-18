﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Nhsneuro
{
    using System.Configuration;
    using System.Web.Http.Cors;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
