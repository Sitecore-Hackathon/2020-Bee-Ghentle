using System;

namespace Feature.Usergroups.Events
{
    public class UsergroupEvent
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime Date { get; set; }
    }
}