using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Repository
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            UserInfo = new HashSet<UserInfo>();
        }

        public int UserTypeId { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
