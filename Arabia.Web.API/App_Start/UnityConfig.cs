using Microsoft.Practices.Unity;
using System.Web.Http;
using Arabia.Core.Data;
using Arabia.Data;
using Arabia.Service.Interviews;
using Unity.WebApi;

namespace Arabia.Web.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType(typeof(IMongoRepository<>), typeof(MongoDbRepository<>), new InjectionConstructor("MongoDB"));
            container.RegisterType<IInterviewService, InterviewService>(); ;
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}