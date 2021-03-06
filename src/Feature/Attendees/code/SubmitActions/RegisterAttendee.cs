﻿using System;
using System.Linq;
using System.Web.Security;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.Security.Accounts;

namespace Feature.Attendees.SubmitActions
{
    public class RegisterAttendee : SubmitActionBase<string>
    {
        public RegisterAttendee(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            try
            {
                var userName = GetFormValue(formSubmitContext, "username");
                var email = GetFormValue(formSubmitContext, "email");
                var password = GetFormValue(formSubmitContext, "password");
                var firstName = GetFormValue(formSubmitContext, "firstname");
                var lastName = GetFormValue(formSubmitContext, "lastname");

                var fullyQualifiedUserName = $"extranet\\{userName}";
                if (!User.Exists(fullyQualifiedUserName))
                {
                    Membership.CreateUser(fullyQualifiedUserName, password, email);
                    // Edit the profile information
                    var user = User.FromName(fullyQualifiedUserName, true);
                    var userProfile = user.Profile;
                    userProfile.FullName = $"{firstName} {lastName}";

                    userProfile.Save();
                }
                else
                {
                    Sitecore.Diagnostics.Log.Error("User exist", this);
                    return false;
                }
            }
            catch (MembershipCreateUserException ex)
            {
                Sitecore.Diagnostics.Log.Error("Message", ex, this);
            }

            return true;
        }

        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        private static string GetFormValue(FormSubmitContext formSubmitContext, string formFieldName)
        {
            var field = formSubmitContext.Fields.FirstOrDefault(f => f.Name.Equals(formFieldName, StringComparison.OrdinalIgnoreCase));
            return field?.GetType().GetProperty("Value")?.GetValue(field, null)?.ToString() ?? string.Empty;
        }
    }
}