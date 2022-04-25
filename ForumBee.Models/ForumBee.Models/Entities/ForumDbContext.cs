using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ForumITUDA.Models.Entities
{
    public partial class ForumDbContext : DbContext
    {
        public ForumDbContext()
        {
        }

        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountVerification> AccountVerifications { get; set; } = null!;
        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<AnswerVote> AnswerVotes { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogCategory> BlogCategories { get; set; } = null!;
        public virtual DbSet<BlogTag> BlogTags { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupRole> GroupRoles { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionComment> QuestionComments { get; set; } = null!;
        public virtual DbSet<QuestionSaved> QuestionSaveds { get; set; } = null!;
        public virtual DbSet<QuestionTag> QuestionTags { get; set; } = null!;
        public virtual DbSet<QuestionVote> QuestionVotes { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Scholastic> Scholastics { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserGroupRole> UserGroupRoles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UsersUdum> UsersUda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountVerification>(entity =>
            {
                entity.ToTable("AccountVerification");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiryOn).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AccountVerifications)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__AccountVe__IdUse__37A5467C");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Answers__Questio__4AB81AF0");
            });

            modelBuilder.Entity<AnswerVote>(entity =>
            {
                entity.ToTable("AnswerVote");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.IdAnswerNavigation)
                    .WithMany(p => p.AnswerVotes)
                    .HasForeignKey(d => d.IdAnswer)
                    .HasConstraintName("FK__AnswerVot__IdAns__4D94879B");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AnswerVotes)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__AnswerVot__IdUse__4E88ABD4");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.Thumbnail).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BlogCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Blogs__CreatedBy__66603565");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Blogs__IdCategor__656C112C");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.BlogUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__Blogs__UpdatedBy__6754599E");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlogTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.IdBlogNavigation)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.IdBlog)
                    .HasConstraintName("FK__BlogTags__IdBlog__6A30C649");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.IdTag)
                    .HasConstraintName("FK__BlogTags__IdTag__6B24EA82");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Grade__MajorId__286302EC");

                entity.HasOne(d => d.Scholastic)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.ScholasticId)
                    .HasConstraintName("FK__Grade__Scholasti__29572725");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Groups__CreatedB__6E01572D");
            });

            modelBuilder.Entity<GroupRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK__Notificat__Answe__60A75C0F");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__Notificat__Comme__5FB337D6");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Notificat__Creat__5DCAEF64");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Notificat__Quest__5EBF139D");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Questions__Categ__3E52440B");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.QuestionCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Questions__Creat__3F466844");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.QuestionUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__Questions__Updat__403A8C7D");
            });

            modelBuilder.Entity<QuestionComment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionComments)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__QuestionC__Quest__5535A963");
            });

            modelBuilder.Entity<QuestionSaved>(entity =>
            {
                entity.ToTable("QuestionSaved");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.QuestionSaveds)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__QuestionS__Creat__52593CB8");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.QuestionSaveds)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("FK__QuestionS__IdQue__5165187F");
            });

            modelBuilder.Entity<QuestionTag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.QuestionTags)
                    .HasForeignKey(d => d.IdQuestion)
                    .HasConstraintName("FK__QuestionT__IdQue__4316F928");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.QuestionTags)
                    .HasForeignKey(d => d.IdTag)
                    .HasConstraintName("FK__QuestionT__IdTag__440B1D61");
            });

            modelBuilder.Entity<QuestionVote>(entity =>
            {
                entity.ToTable("QuestionVote");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionVotes)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__QuestionV__Quest__46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuestionVotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__QuestionV__UserI__47DBAE45");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK__Reports__AnswerI__59FA5E80");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__Reports__Comment__59063A47");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Reports__Created__5AEE82B9");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK__Reports__Questio__5812160E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Scholastic>(entity =>
            {
                entity.ToTable("Scholastic");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Slug).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailVerifiedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(70);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UrlAvatar)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserGroupRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__UserGrou__AF2760AD7E4DF106");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserGroupRoles)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__UserGroup__Group__73BA3083");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserGroupRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserGroup__RoleI__74AE54BC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGroupRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserGroup__UserI__72C60C4A");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__UserRole__AF2760AD5498902A");

                entity.ToTable("UserRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__RoleId__34C8D9D1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__UserId__33D4B598");
            });

            modelBuilder.Entity<UsersUdum>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UsersUDA__1788CC4C6FAC6F2D");

                entity.ToTable("UsersUDA");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.UsersUda)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__UsersUDA__GradeI__787EE5A0");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UsersUdum)
                    .HasForeignKey<UsersUdum>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersUDA__UserId__778AC167");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
