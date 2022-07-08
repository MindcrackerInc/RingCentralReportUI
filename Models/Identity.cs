using System;
using System.Collections.Generic;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class Identity
    {
        public List<Thread> Threads { get; set; }
        public List<InterventionComment> interventionsComments { get; set; }
        public long RowId { get; set; }
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CommunityId { get; set; }
        public string CommunityUrl { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string ForeignId { get; set; }
        public string Gender { get; set; }
        public string HomePhone { get; set; }
        public string IdentityGroupId { get; set; }
        public string Lastname { get; set; }
        public string MobilePhone { get; set; }
        public string Screenname { get; set; }
        public string UserIds { get; set; }
        public string Uuid { get; set; }
        public string ExtraValues { get; set; }
        public string DisplayName { get; set; }
        public string AvatarUrl { get; set; }
        public string Type { get; set; }
    }
}
