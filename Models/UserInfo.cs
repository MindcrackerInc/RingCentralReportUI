using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RingCentralReport.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
