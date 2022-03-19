using System;
using System.Collections.Generic;



namespace SchemasForFarmer.Repository
{
    public partial class Bidding
    {
        public int BiddingId { get; set; }
        public decimal? BidAmt { get; set; }
        public DateTime? BidDate { get; set; }
        public bool? IsBitStatus { get; set; }
        public int? UserId { get; set; }
        public int? SellId { get; set; }

        public virtual Sell Sell { get; set; }
        public virtual UserInfo User { get; set; }
    }
}
