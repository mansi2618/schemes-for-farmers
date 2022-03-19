using Microsoft.AspNetCore.Mvc;
using SchemasForFarmer.DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.Controllers
{
    [Route("api/History")]
    [ApiController]
    public class ViewSoldCropHistoryController : Controller
    {
        private IViewSoldCropHistoryDao viewSoldCropHistory;
        public ViewSoldCropHistoryController(IViewSoldCropHistoryDao historyPageDao)
        {
            viewSoldCropHistory = historyPageDao;
        }

        [HttpGet]
        public IActionResult FetchAllHistoryDetails()
        {
            var fetchedData = viewSoldCropHistory.FetchAllHistoryDetails();
            return this.Ok(fetchedData);
        }
        [HttpGet]
        [Route("{UserId}")]
        public IActionResult FetchHistoryById(int id)
        {
            ViewSoldCropHistoryDao requestPageDao = new ViewSoldCropHistoryDao();
            var fetchedData = requestPageDao.FetchHistoryById(id);
            return this.Ok(fetchedData);

        }
        [HttpPost]
        public IActionResult InsertSellRequestInfo(ViewSoldCropHistoryDao historyData)
        {
            ViewSoldCropHistoryDao historyPageDao = new ViewSoldCropHistoryDao();
            var result = historyPageDao.InsertCropHistoryInfo(historyData);
            return this.CreatedAtAction(
                "InsertHistoryInfo",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = historyData
                }
                );
        }
    }
}
