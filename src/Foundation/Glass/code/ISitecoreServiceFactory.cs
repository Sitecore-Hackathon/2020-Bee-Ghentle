using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;

namespace Foundation.Glass
{
    public interface ISitecoreServiceFactory
    {
        ISitecoreService GetSitecoreService();
        IRequestContext GetRequestContext();
        IMvcContext GetMvcContext();
    }
}