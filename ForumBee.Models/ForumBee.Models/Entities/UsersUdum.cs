using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class UsersUdum
    {
        public Guid UserId { get; set; }
        public Guid? GradeId { get; set; }
        public string? UserName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Grade? Grade { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
