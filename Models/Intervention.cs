using System;
using System.Collections.Generic;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class Intervention
    {
        public long RowId { get; set; }
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CustomFieldValues { get; set; }
        public string CategoryIds { get; set; }
        public bool? Closed { get; set; }
        public DateTime? ClosedAt { get; set; }
        public int? CommentsCount { get; set; }
        public string ContentId { get; set; }
        public DateTime? DeferredAt { get; set; }
        public int? FirstUserReplyIn { get; set; }
        public int? FirstUserReplyInBh { get; set; }
        public string IdentityId { get; set; }
        public int? LastUserReplyIn { get; set; }
        public int? LastUserReplyInBh { get; set; }
        public string SourceId { get; set; }
        public string ThreadId { get; set; }
        public string UserId { get; set; }
        public int? UserRepliesCount { get; set; }
        public int? UserReplyInAverage { get; set; }
        public int? UserReplyInAverageBh { get; set; }
        public int? UserReplyInAverageCount { get; set; }
        public string FirstUserReplyId { get; set; }
        public string Status { get; set; }
        public string SatisfactionGrade { get; set; }
        public DateTime? SatisfactionAnsweredAt { get; set; }
        public DateTime? SatisfactionSentAt { get; set; }
        public string SurveyResponseId { get; set; }
        public string SurveyId { get; set; }
    }
}
