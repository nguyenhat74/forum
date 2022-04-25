using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class Grade
    {
        public Grade()
        {
            UsersUda = new HashSet<UsersUdum>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? MajorId { get; set; }
        public Guid? ScholasticId { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Major? Major { get; set; }
        public virtual Scholastic? Scholastic { get; set; }
        public virtual ICollection<UsersUdum> UsersUda { get; set; }
    }
}
