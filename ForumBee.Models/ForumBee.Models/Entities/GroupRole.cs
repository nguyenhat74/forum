using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class GroupRole
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
