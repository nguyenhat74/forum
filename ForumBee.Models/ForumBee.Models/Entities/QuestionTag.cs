using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class QuestionTag
    {
        public Guid Id { get; set; }
        public Guid? IdQuestion { get; set; }
        public Guid? IdTag { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Question? IdQuestionNavigation { get; set; }
        public virtual Tag? IdTagNavigation { get; set; }
    }
}
