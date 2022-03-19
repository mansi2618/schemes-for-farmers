using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Models
{
    public partial class LoginInfo
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int? UserId { get; set; }
        public int? UserTypeId { get; set; }

        public virtual UserInfo User { get; set; }
        public virtual UserDetails UserType { get; set; }
    }
}
