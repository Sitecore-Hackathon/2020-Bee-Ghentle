using System;
using System.Linq;
using Foundation.Glass;
using Glass.Mapper;
using Glass.Mapper.Sc;
using Scriban.Runtime;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.XA.Foundation.Abstractions;
using Sitecore.XA.Foundation.Scriban.Pipelines.GenerateScribanContext;

namespace Feature.Usergroups.Events
{
    public class GetNextEvent : IGenerateScribanContextProcessor
    {
        private readonly ISitecoreServiceFactory sitecoreServiceFactory;
        private readonly IContext context;

        public GetNextEvent(ISitecoreServiceFactory sitecoreServiceFactory, IContext context)
        {
            this.sitecoreServiceFactory = sitecoreServiceFactory;
            this.context = context;
        }

        private delegate Item NextEvent(Item currentItem);

        public void Process(GenerateScribanContextPipelineArgs args)
        {
            var nextEvent = new NextEvent(GetEvent);
            args.GlobalScriptObject.Import("sc_nextevent", nextEvent);
        }

        public Item GetEvent(Item currentItem)
        {
            var sitecoreContext = sitecoreServiceFactory.GetSitecoreService();
            var options = new GetItemsByQueryOptions
            {
                Query = new Query("./*"),
                RelativeItem = currentItem,
                VersionCount = true,
                Lazy = LazyLoading.Disabled
            };

            var nexti = sitecoreContext.GetItems<UsergroupEvent>(options);
            var next = nexti.Where(i => i.Date > DateTime.Now).OrderBy(d => d.Date).FirstOrDefault();
            return next != null ? context.Database.GetItem(new ID(next.Id)) : null;
        }
    }
}