using System;
using System.Collections.Generic;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class Thread
    {
        public long RowId { get; set; }
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CategoryIds { get; set; }
        public bool? Closed { get; set; }
        public int? ContentsCount { get; set; }
        public string ExtraData { get; set; }
        public string ForeignId { get; set; }
        public int? InterventionsCount { get; set; }
        public string SourceId { get; set; }
        public string ThreadCategoryIds { get; set; }
        public string Title { get; set; }
        public DateTime? LastContentAt { get; set; }
        public DateTime? FirstCategorizationAt { get; set; }
        public string FirstContentId { get; set; }
        public string FirstContentAuthorId { get; set; }
        public string LastContentId { get; set; }
        public string InterventionUserIds { get; set; }
        public string OpenedInterventionUserIds { get; set; }
    }
}
