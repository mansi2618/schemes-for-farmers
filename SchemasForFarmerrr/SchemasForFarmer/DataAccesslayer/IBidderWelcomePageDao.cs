using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.DataAccesslayer
{
    public interface IBidderWelcomePageDao
    {
        /*bool InsertCropName(BidderWelcomePageDao cropname);
        bool InsertCropType(BidderWelcomePageDao croptype);
        bool InsertBasePrice(BidderWelcomePageDao baseprice);
        bool InsertCurrentBid(BidderWelcomePageDao currentbid);
        bool InsertBidAmount(BidderWelcomePageDao bidamount);
        bool InsertUserId(BidderWelcomePageDao userid);
        bool InsertBidder(BidderWelcomePageDao bidder);*/
        BidderWelcomePageDao FetchDetailsById(int id);
        List<BidderWelcomePageDao> FetchAllDetails();
        bool InsertBidderInfo(BidderWelcomePageDao p);
    }
}
