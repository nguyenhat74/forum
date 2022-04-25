using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class QuestionVote
    {
        public Guid Id { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? UserId { get; set; }
        public bool? Type { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Question? Question { get; set; }
        public virtual User? User { get; set; }
    }
}
