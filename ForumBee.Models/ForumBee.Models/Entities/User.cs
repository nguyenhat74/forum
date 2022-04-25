using System;
using System.Collections.Generic;

namespace ForumITUDA.Models.Entities
{
    public partial class User
    {
        public User()
        {
            AccountVerifications = new HashSet<AccountVerification>();
            AnswerVotes = new HashSet<AnswerVote>();
            BlogCreatedByNavigations = new HashSet<Blog>();
            BlogUpdatedByNavigations = new HashSet<Blog>();
            Groups = new HashSet<Group>();
            Notifications = new HashSet<Notification>();
            QuestionCreatedByNavigations = new HashSet<Question>();
            QuestionSaveds = new HashSet<QuestionSaved>();
            QuestionUpdatedByNavigations = new HashSet<Question>();
            QuestionVotes = new HashSet<QuestionVote>();
            Reports = new HashSet<Report>();
            UserGroupRoles = new HashSet<UserGroupRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime? EmailVerifiedOn { get; set; }
        public bool? EmailConfig { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? PhoneNumberConfig { get; set; }
        public string? UrlAvatar { get; set; }
        public string? Address { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsVerification { get; set; }
        public bool? IsActive { get; set; }

        public virtual UsersUdum UsersUdum { get; set; } = null!;
        public virtual ICollection<AccountVerification> AccountVerifications { get; set; }
        public virtual ICollection<AnswerVote> AnswerVotes { get; set; }
        public virtual ICollection<Blog> BlogCreatedByNavigations { get; set; }
        public virtual ICollection<Blog> BlogUpdatedByNavigations { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Question> QuestionCreatedByNavigations { get; set; }
        public virtual ICollection<QuestionSaved> QuestionSaveds { get; set; }
        public virtual ICollection<Question> QuestionUpdatedByNavigations { get; set; }
        public virtual ICollection<QuestionVote> QuestionVotes { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<UserGroupRole> UserGroupRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
