using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class Tag
    {
        public Tag()
        {
            BlogTags = new HashSet<BlogTag>();
            QuestionTags = new HashSet<QuestionTag>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<BlogTag> BlogTags { get; set; }
        public virtual ICollection<QuestionTag> QuestionTags { get; set; }
    }
}
