using Microsoft.AspNetCore.Mvc;
using SchemasForFarmer.DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.Controllers
{
    [Route("bidderpageApi/[controller]")]
    [ApiController]
    public class ViewMarketPlaceController : Controller
    {
        private IViewmarketplace viewMarketPlaceeDao;
        public ViewMarketPlaceController(IViewmarketplace marketPlaceDao)
        {
            viewMarketPlaceeDao = marketPlaceDao;
        }

        [HttpGet]
        public IActionResult GFetchAllMarketDetails()
        {
            //BidderWelcomePageDao bidderPageDao = new BidderWelcomePageDao();
            var fetchedData = viewMarketPlaceeDao.FetchAllMarketDetails();
            return this.Ok(fetchedData);
        }
        [HttpGet]
        [Route("{UserId}")]
        public IActionResult FetchMarketDetailsById(int id)
        {
            ViewMarketPlaceDao marketPlaceDao = new ViewMarketPlaceDao();
            var fetchedData = marketPlaceDao.FetchMarketDetailsById(id);
            return this.Ok(fetchedData);

        }
        [HttpPost]
        public IActionResult InsertMarketPlaceInfo(ViewMarketPlaceDao MarketDetails)
        {
            ViewMarketPlaceDao marketPlaceDao = new ViewMarketPlaceDao();
            var result = marketPlaceDao.InsertMarketPlaceInfo(MarketDetails);
            return this.CreatedAtAction(
                "InsertBidderInfo",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = MarketDetails
                }
                );
        }
    }
}
