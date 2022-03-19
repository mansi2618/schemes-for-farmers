using Microsoft.AspNetCore.Mvc;
using SchemasForFarmer.DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SchemasForFarmer.Controllers
{
    [Route("api/alldetails")]
    [ApiController]
    public class BidderWelcomePageController : Controller
    {
        private IBidderWelcomePageDao bidderWelcomePageDao;
        public BidderWelcomePageController(IBidderWelcomePageDao bidderPageDao)
        {
            bidderWelcomePageDao = bidderPageDao;
        }

        [HttpGet]
        public IActionResult FetchAllDetails()
        {
            //BidderWelcomePageDao bidderPageDao = new BidderWelcomePageDao();
            var fetchedData = bidderWelcomePageDao.FetchAllDetails();
            return this.Ok(fetchedData);
        }
        [HttpGet]
        [Route("{UserId}")]
        public IActionResult FetchDetailsById(int id)
        {
            BidderWelcomePageDao marketPlaceDao = new BidderWelcomePageDao();
            var fetchedData = marketPlaceDao.FetchDetailsById( id);
            return this.Ok(fetchedData);

        }
        [HttpPost]
        public IActionResult InsertBidderInfo(BidderWelcomePageDao bidder)
        {
            BidderWelcomePageDao marketPlaceDao = new BidderWelcomePageDao();
            var result = marketPlaceDao.InsertBidderInfo(bidder);
            return this.CreatedAtAction(
                "InsertBidderInfo",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = bidder
                }
                );
        }
    }
}
