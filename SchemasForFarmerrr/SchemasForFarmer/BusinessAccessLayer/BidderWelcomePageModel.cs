using SchemasForFarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.BusinessAccessLayer
{
    public class BidderWelcomePageModel
    {
        public BidderWelcomePageModel()
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
