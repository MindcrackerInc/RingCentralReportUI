using System;
using System.Collections.Generic;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class IdentityGroup
    {
        public long RowId { get; set; }
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CustomFieldValues { get; set; }
        public string Company { get; set; }
        public string Emails { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string HomePhones { get; set; }
        public string MobilePhones { get; set; }
        public string IdentityIds { get; set; }
        public string Notes { get; set; }
        public bool? ReadOnly { get; set; }
        public string TagIds { get; set; }
        public string AvatarUrl { get; set; }
    }
}
