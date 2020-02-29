using System;
using Sitecore.Data.Items;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace Feature.Attendees.Fields
{
    [Serializable]
    public class HiddenContextItemViewModel : InputViewModel<string>
    {
        public string ContextItemId { get; set; }
        public HiddenContextItemViewModel()
        {
            if (string.IsNullOrEmpty(ContextItemId))
            {
                ContextItemId = Sitecore.Context.Item.ID.Guid.ToString();
            }
        }
        protected override void InitItemProperties(Item item)
        {
            base.InitItemProperties(item);
        }

        protected override void UpdateItemFields(Item item)
        {
            base.UpdateItemFields(item);
        }

    }
}