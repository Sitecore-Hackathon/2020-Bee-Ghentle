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
        private const string NamePattern = "^[a-zA-Z ]*$";

        public UserNameUniqueValidator(ValidationDataModel validationItem) : base(validationItem)
        {
        }

        public override IEnumerable<ModelClientValidationRule> ClientValidationRules { get; }

        public string Title { get; set; }

        public override ValidationResult Validate(object value)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var stringValue = (string)value;
            if (!User.Exists(stringValue))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(FormatMessage(Title));
        }


        public override void Initialize(object validationModel)
        {
            base.Initialize(validationModel);

            var obj = validationModel as StringInputViewModel;
            if (obj != null)
            {
                Title = obj.Title;
            }
        }
    }
}