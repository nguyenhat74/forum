using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class QuestionSaved
    {
        public Guid Id { get; set; }
        public Guid? IdQuestion { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual Question? IdQuestionNavigation { get; set; }
    }
}
