using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using Sitecore.ExperienceForms.Mvc.Models.Validation;
using Sitecore.Security.Accounts;

namespace Feature.Attendees.Validators
{
    public class UserNameUniqueValidator : ValidationElement<string>
    {
        public UserNameUniqueValidator(ValidationDataModel validationItem) : base(validationItem)
        {
        }

        public string Title { get; set; }

        public override IEnumerable<ModelClientValidationRule> ClientValidationRules => new List<ModelClientValidationRule>();

        public override ValidationResult Validate(object value)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var stringValue = (string)value;
            var fullyQualifiedUserName = $"extranet\\{stringValue}";
            return !User.Exists(fullyQualifiedUserName) ? ValidationResult.Success : new ValidationResult(FormatMessage(Title));
        }

        public override void Initialize(object validationModel)
        {
            base.Initialize(validationModel);

            if (validationModel is StringInputViewModel obj)
            {
                Title = obj.Title;
            }
        }
    }
}