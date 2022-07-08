using System;
using System.Collections.Generic;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class InterventionComment
    {
        public long RowId { get; set; }
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Body { get; set; }
        public string IdentityId { get; set; }
        public string InterventionId { get; set; }
        public string SourceId { get; set; }
        public string ThreadId { get; set; }
        public string UserId { get; set; }
    }
}
