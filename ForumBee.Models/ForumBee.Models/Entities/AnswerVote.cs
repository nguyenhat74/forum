using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class AnswerVote
    {
        public Guid Id { get; set; }
        public Guid? IdAnswer { get; set; }
        public Guid? IdUser { get; set; }
        public bool? Type { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Answer? IdAnswerNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
    }
}
