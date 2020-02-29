using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace Project.Platform
{
    public class ApplicationStart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "args", Justification = "By design")]
#pragma warning disable CA1822 // Mark members as static
        public void Process(PipelineArgs args)
#pragma warning restore CA1822 // Mark members as static
        {
            MvcHandler.DisableMvcResponseHeader = true;
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}