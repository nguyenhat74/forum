using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class Group
    {
        public Group()
        {
            UserGroupRoles = new HashSet<UserGroupRole>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? MaximumPeople { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }
}
