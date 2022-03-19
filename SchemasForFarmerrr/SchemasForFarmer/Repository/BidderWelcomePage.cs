using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Repository
{
    public partial class BidderWelcomePage
    {
        public string CropName { get; set; }
        public string CropType { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? CurrentBid { get; set; }
        public decimal? Bidammount { get; set; }
        public int? UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
