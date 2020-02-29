using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.SecurityModel;

namespace Feature.Attendees.Areas.Attendees.Controllers
{
    public class AttendeesController : Controller
    {
        public ActionResult SubscribeToEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubscribeToEvent(string param)
        {
            using (new SecurityDisabler())
            {
                var page = Sitecore.Context.Item;

                var username = Sitecore.Security.Accounts.User.Current.IsAuthenticated
                    ? Sitecore.Security.Accounts.User.Current.Name : null;

                string currentValue = page["subscribers"];
                if (!string.IsNullOrEmpty(username))
                {
                    string newEntry = $"{username.Remove(0, 9)}";
                    if (currentValue == null || !currentValue.Contains(newEntry))
                    {
                        string newVal = currentValue + "|" + newEntry;

                        page.Editing.BeginEdit();
                        page["subscribers"] = newVal;
                        page.Editing.EndEdit();

                        var master = Sitecore.Configuration.Factory.GetDatabase("master");
                        var pageMaster = master.GetItem(page.ID);

                        pageMaster.Editing.BeginEdit();
                        pageMaster["subscribers"] = newVal;
                        pageMaster.Editing.EndEdit();
                    }
                }
            }
            return new EmptyResult();
        }
    }
}