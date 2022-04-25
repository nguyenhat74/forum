using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class UserGroupRole
    {
        public Guid UserId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid RoleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Group? Group { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
