using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.Security.Accounts;

namespace Feature.Attendees.SubmitActions
{
    public class SubscribeToEvent : SubmitActionBase<string>
    {
        public SubscribeToEvent(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            var currentUsername = User.Current?.GetDomainName();
            var page = Sitecore.Context.Item;
            var field = page?.Fields["Attendees"];
            if (!string.IsNullOrEmpty(currentUsername) && field != null)
            {
                var value = field.Value;
                if (string.IsNullOrEmpty(value))
                {
                    field.Value = currentUsername;
                }
                else if (!value.Contains(currentUsername))
                {
                    field.Value += $"|{currentUsername}";
                }
                return true;
            }
            return false;

        }

        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }
    }
}