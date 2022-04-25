using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumITUDA.Models.Dto
{
    public class UpdateBlogDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public int? ViewCount { get; set; }
        public string? Thumbnail { get; set; }
        public Guid? IdCategory { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsActive { get; set; }
    }
}
