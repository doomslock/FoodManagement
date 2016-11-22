using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using FoodManagement.DependencyResolution;
using Ninject;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(FoodManagement.Service.WebAPI.Startup))]
namespace FoodManagement.Service.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
        }

        private static StandardKernel CreateKernel()
        {
            DependencyConfiguration depConfig = new DependencyConfiguration();
            var kernel = depConfig.Kernel;
            return kernel;
        }
    }
}