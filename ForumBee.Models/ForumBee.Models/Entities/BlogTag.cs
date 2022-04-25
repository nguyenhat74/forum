using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class BlogTag
    {
        public Guid Id { get; set; }
        public Guid? IdBlog { get; set; }
        public Guid? IdTag { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Blog? IdBlogNavigation { get; set; }
        public virtual Tag? IdTagNavigation { get; set; }
    }
}
