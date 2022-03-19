using Microsoft.AspNetCore.Mvc;
using SchemasForFarmer.DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.Controllers
{
    [Route("requestpageApi/[controller]")]
    [ApiController]
    public class PlaceSellRequestController : Controller
    {
        private IPlaceSellRequestDao placeSellRequestDao;
        public PlaceSellRequestController(IPlaceSellRequestDao requestPageDao)
        {
            placeSellRequestDao = requestPageDao;
        }

        [HttpGet]
        public IActionResult FetchAllRequestDetails()
        {
            //PlaceSellRequestDao requestPageDao = new PlaceSellRequestDao();
            var fetchedData = placeSellRequestDao.FetchAllRequestDetails();
            return this.Ok(fetchedData);
        }
        [HttpGet]
        [Route("{UserId}")]
        public IActionResult FetchDetailsById(int id)
        {
            PlaceSellRequestDao requestPageDao = new PlaceSellRequestDao();
            var fetchedData = requestPageDao.FetchDetailsById(id);
            return this.Ok(fetchedData);

        }
        [HttpPost]
        public IActionResult InsertSellRequestInfo(PlaceSellRequestDao data)
        {
            PlaceSellRequestDao requestPageDao = new PlaceSellRequestDao();
            var result = requestPageDao.InsertSellRequestInfo(data);
            return this.CreatedAtAction(
                "InsertBidderInfo",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = data
                }
                );
        }
    }
}
