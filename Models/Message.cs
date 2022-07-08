using System;
using System.Collections.Generic;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class Message
    {
        public long Rowid { get; set; }
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string SourceId { get; set; }
        public string SourceType { get; set; }
        public string SourceName { get; set; }
        public string ContentThreadId { get; set; }
        public string Type { get; set; }
        public string PrivateMessage { get; set; }
        public string CreatedFrom { get; set; }
        public bool? AutoSubmitted { get; set; }
        public string Status { get; set; }
        public string IgnoredFrom { get; set; }
        public string Categories { get; set; }
        public string InterventionId { get; set; }
        public DateTime? InitialCreatedAt { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Anonymized { get; set; }
        public string Body { get; set; }
        public string BodyAsText { get; set; }
        public string BodyAsHtml { get; set; }
        public string Title { get; set; }
        public string ForeignCategories { get; set; }
        public string ForeignId { get; set; }
        public string Rating { get; set; }
        public string Published { get; set; }
        public bool? ApprovalRequired { get; set; }
        public bool? RemotelyDeleted { get; set; }
        public string Language { get; set; }
        public string InReplyToId { get; set; }
        public string InReplyToAuthorId { get; set; }
        public int? AttachmentsCount { get; set; }
        public string StructuredReplyPayload { get; set; }
    }
}
