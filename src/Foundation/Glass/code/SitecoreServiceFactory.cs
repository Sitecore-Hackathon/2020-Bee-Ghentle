using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Glass
{
    public class SitecoreServiceFactory : ISitecoreServiceFactory
    {
        public ISitecoreService GetSitecoreService() => Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<ISitecoreService>();
        public IRequestContext GetRequestContext() => Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IRequestContext>();
        public IMvcContext GetMvcContext() => Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService<IMvcContext>();
    }
}