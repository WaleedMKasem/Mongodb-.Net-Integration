using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Arabia.Core.Data;
using Arabia.Data;
using Arabia.Service.Interviews;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace Arabia.Web.API
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(BuildApiContainer());
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        public static UnityContainer BuildApiContainer()
        {
            var container = new UnityContainer();
            container.RegisterType(typeof(IMongoRepository<>), typeof(MongoDbRepository<>));
            container.RegisterType<IInterviewService, InterviewService>(); ;

            return container;
        }
    }
}