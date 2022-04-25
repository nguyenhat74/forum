using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            Notifications = new HashSet<Notification>();
            QuestionComments = new HashSet<QuestionComment>();
            QuestionSaveds = new HashSet<QuestionSaved>();
            QuestionTags = new HashSet<QuestionTag>();
            QuestionVotes = new HashSet<QuestionVote>();
            Reports = new HashSet<Report>();
        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public int? ViewCount { get; set; }
        public string? Icon { get; set; }
        public Guid? CategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsActive { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? CreatedByNavigation { get; set; }
        public virtual User? UpdatedByNavigation { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<QuestionComment> QuestionComments { get; set; }
        public virtual ICollection<QuestionSaved> QuestionSaveds { get; set; }
        public virtual ICollection<QuestionTag> QuestionTags { get; set; }
        public virtual ICollection<QuestionVote> QuestionVotes { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
