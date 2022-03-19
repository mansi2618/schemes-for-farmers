using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Models
{
    public partial class BidderWelcomePage

    {
        internal int CropTypeId;

        public BidderWelcomePage()
        {
            User = new HashSet<UserInfo>();
        }

        public string CropName { get; set; }
        public string CropType { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? CurrentBid { get; set; }
        public decimal? Bidamount { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<UserInfo> User { get; set; }
    }
}
