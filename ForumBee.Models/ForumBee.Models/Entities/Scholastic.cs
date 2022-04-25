using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class Scholastic
    {
        public Scholastic()
        {
            Grades = new HashSet<Grade>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
