using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserGroupRoles = new HashSet<UserGroupRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
