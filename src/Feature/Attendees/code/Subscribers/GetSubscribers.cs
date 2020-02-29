using System.Collections.Generic;
using System.Linq;
using Scriban.Runtime;
using Sitecore.Data.Items;
using Sitecore.Security.Accounts;
using Sitecore.XA.Foundation.Scriban.Pipelines.GenerateScribanContext;

namespace Feature.Attendees.Subscribers
{
    public class GetSubscribers : IGenerateScribanContextProcessor
    {
        private delegate IEnumerable<string> Subscribers(Item currentItem);

        public void Process(GenerateScribanContextPipelineArgs args)
        {
            var subscribers = new Subscribers(GetSubscriberList);
            args.GlobalScriptObject.Import("sc_subscribers", subscribers);
        }

        public IEnumerable<string> GetSubscriberList(Item currentItem)
        {
            var users = currentItem.Fields["Subscribers"].Value.Split('|');
            const string domainName = "extranet";
            var userList = new List<User>();
            foreach (var userName in users)
            {
                if (User.Exists(domainName + @"\" + userName))
                {
                    userList.Add(User.FromName(domainName + @"\" + userName, false));
                }
            }

            return userList.Select(u => u.Profile.FullName);
        }
    }
}