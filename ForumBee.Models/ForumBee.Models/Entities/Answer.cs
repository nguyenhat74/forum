using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class Answer
    {
        public Answer()
        {
            AnswerVotes = new HashSet<AnswerVote>();
            Notifications = new HashSet<Notification>();
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }
        public Guid? QuestionId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual Question? Question { get; set; }
        public virtual ICollection<AnswerVote> AnswerVotes { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
