using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Foundation.Glass
{
    public class GlassMapperConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISitecoreService>(sp => new SitecoreService(Sitecore.Context.Database));
            serviceCollection.AddScoped<IMvcContext>(sp => new MvcContext(sp.GetService<ISitecoreService>()));
            serviceCollection.AddScoped<IRequestContext>(sp => new RequestContext(sp.GetService<ISitecoreService>()));
            serviceCollection.AddScoped<IGlassHtml>(sp => new GlassHtml(sp.GetService<ISitecoreService>()));

            serviceCollection.AddSingleton<ISitecoreServiceFactory>(new SitecoreServiceFactory());
        }
    }
}