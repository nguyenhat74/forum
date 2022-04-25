using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{     
    public partial class Notification
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? Seen { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? AnswerId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Answer? Answer { get; set; }
        public virtual QuestionComment? Comment { get; set; }
        public virtual User? CreatedByNavigation { get; set; }
        public virtual Question? Question { get; set; }
    }
}
