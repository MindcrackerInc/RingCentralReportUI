using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class RignCentral_ReportingContext : DbContext
    {
        //public RignCentral_ReportingContext()
        //{
        //}

        public RignCentral_ReportingContext(DbContextOptions<RignCentral_ReportingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Identity> Identities { get; set; }
        public virtual DbSet<IdentityGroup> IdentityGroups { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }
        public virtual DbSet<InterventionComment> InterventionComments { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=23.101.140.148;uid=RignCentralDev;pwd=RignCentral@2022;database=RignCentral_Reporting;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Identity>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId).HasColumnName("rowId");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("avatar_url");

                entity.Property(e => e.CommunityId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("community_id");

                entity.Property(e => e.CommunityUrl)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("community_url");

                entity.Property(e => e.Company)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ExtraValues)
                    .IsUnicode(false)
                    .HasColumnName("extra_values");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.ForeignId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("foreign_id");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("home_phone");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdentityGroupId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identity_group_id");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mobile_phone");

                entity.Property(e => e.Screenname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("screenname");

                entity.Property(e => e.Type)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserIds)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("user_ids");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("uuid");
            });

            modelBuilder.Entity<IdentityGroup>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId).HasColumnName("rowId");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(4000)
                    .HasColumnName("avatar_url");

                entity.Property(e => e.Company)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomFieldValues)
                    .IsUnicode(false)
                    .HasColumnName("custom_field_values");

                entity.Property(e => e.Emails).HasColumnName("emails");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.HomePhones)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("home_phones");

                entity.Property(e => e.Id)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdentityIds)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("identity_ids");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.MobilePhones)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mobile_phones");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.ReadOnly).HasColumnName("read_only");

                entity.Property(e => e.TagIds)
                    .HasMaxLength(1000)
                    .HasColumnName("tag_ids");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Intervention>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId).HasColumnName("rowId");

                entity.Property(e => e.CategoryIds).HasColumnName("category_ids");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.ClosedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("closed_at");

                entity.Property(e => e.CommentsCount).HasColumnName("comments_count");

                entity.Property(e => e.ContentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("content_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomFieldValues).HasColumnName("custom_field_values");

                entity.Property(e => e.DeferredAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deferred_at");

                entity.Property(e => e.FirstUserReplyId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_user_reply_id");

                entity.Property(e => e.FirstUserReplyIn).HasColumnName("first_user_reply_in");

                entity.Property(e => e.FirstUserReplyInBh).HasColumnName("first_user_reply_in_bh");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdentityId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identity_id");

                entity.Property(e => e.LastUserReplyIn).HasColumnName("last_user_reply_in");

                entity.Property(e => e.LastUserReplyInBh).HasColumnName("last_user_reply_in_bh");

                entity.Property(e => e.SatisfactionAnsweredAt)
                    .HasColumnType("datetime")
                    .HasColumnName("satisfaction_answered_at");

                entity.Property(e => e.SatisfactionGrade)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("satisfaction_grade");

                entity.Property(e => e.SatisfactionSentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("satisfaction_sent_at");

                entity.Property(e => e.SourceId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("source_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.SurveyId)
                    .HasMaxLength(50)
                    .HasColumnName("survey_id");

                entity.Property(e => e.SurveyResponseId)
                    .HasMaxLength(50)
                    .HasColumnName("survey_response_id");

                entity.Property(e => e.ThreadId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("thread_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_id");

                entity.Property(e => e.UserRepliesCount).HasColumnName("user_replies_count");

                entity.Property(e => e.UserReplyInAverage).HasColumnName("user_reply_in_average");

                entity.Property(e => e.UserReplyInAverageBh).HasColumnName("user_reply_in_average_bh");

                entity.Property(e => e.UserReplyInAverageCount).HasColumnName("user_reply_in_average_count");
            });

            modelBuilder.Entity<InterventionComment>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.RowId).HasColumnName("rowId");

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IdentityId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identity_id");

                entity.Property(e => e.InterventionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("intervention_id");

                entity.Property(e => e.SourceId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("source_id");

                entity.Property(e => e.ThreadId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("thread_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.Property(e => e.Rowid).HasColumnName("rowid");

                entity.Property(e => e.Anonymized)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("anonymized");

                entity.Property(e => e.ApprovalRequired).HasColumnName("approval_required");

                entity.Property(e => e.AttachmentsCount).HasColumnName("attachments_count");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("author_id");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("author_name");

                entity.Property(e => e.AutoSubmitted).HasColumnName("auto_submitted");

                entity.Property(e => e.Body)
                    .IsUnicode(false)
                    .HasColumnName("body");

                entity.Property(e => e.BodyAsHtml).HasColumnName("body_as_html");

                entity.Property(e => e.BodyAsText)
                    .IsUnicode(false)
                    .HasColumnName("body_as_text");

                entity.Property(e => e.Categories)
                    .IsUnicode(false)
                    .HasColumnName("categories");

                entity.Property(e => e.ContentThreadId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("content_thread_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedFrom)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("created_from");

                entity.Property(e => e.CreatorId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("creator_id");

                entity.Property(e => e.CreatorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("creator_name");

                entity.Property(e => e.ForeignCategories)
                    .IsUnicode(false)
                    .HasColumnName("foreign_categories");

                entity.Property(e => e.ForeignId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("foreign_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.IgnoredFrom)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ignored_from");

                entity.Property(e => e.InReplyToAuthorId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("in_reply_to_author_id");

                entity.Property(e => e.InReplyToId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("in_reply_to_id");

                entity.Property(e => e.InitialCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("initial_created_at");

                entity.Property(e => e.InterventionId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("intervention_id");

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.PrivateMessage)
                    .IsUnicode(false)
                    .HasColumnName("private_message");

                entity.Property(e => e.Published)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("published");

                entity.Property(e => e.Rating)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rating");

                entity.Property(e => e.RemotelyDeleted).HasColumnName("remotely_deleted");

                entity.Property(e => e.SourceId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("source_id");

                entity.Property(e => e.SourceName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("source_name");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("source_type");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength(true);

                entity.Property(e => e.StructuredReplyPayload).HasColumnName("structured_reply_payload");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Thread>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.Property(e => e.CategoryIds).HasColumnName("category_ids");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.ContentsCount).HasColumnName("contents_count");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.ExtraData).HasColumnName("extra_data");

                entity.Property(e => e.FirstCategorizationAt)
                    .HasColumnType("datetime")
                    .HasColumnName("first_categorization_at");

                entity.Property(e => e.FirstContentAuthorId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_content_author_id");

                entity.Property(e => e.FirstContentId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_content_id");

                entity.Property(e => e.ForeignId)
                    .HasMaxLength(500)
                    .HasColumnName("foreign_id");

                entity.Property(e => e.Id)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InterventionUserIds).HasColumnName("intervention_user_ids");

                entity.Property(e => e.InterventionsCount).HasColumnName("interventions_count");

                entity.Property(e => e.LastContentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("last_content_at");

                entity.Property(e => e.LastContentId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_content_id");

                entity.Property(e => e.OpenedInterventionUserIds).HasColumnName("opened_intervention_user_ids");

                entity.Property(e => e.SourceId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("source_id");

                entity.Property(e => e.ThreadCategoryIds).HasColumnName("thread_category_ids");

                entity.Property(e => e.Title)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserInfo");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
