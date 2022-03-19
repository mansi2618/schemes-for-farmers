using Microsoft.AspNetCore.Mvc;
using SchemasForFarmer.DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.Controllers
{
    [Route("cropApi/[controller]")]
    [ApiController]
    public class CropController : Controller
    {


        private ICropDetail cropDao;
        public CropController(ICropDetail  cropDetail)
        {
            Console.WriteLine("controller created...");
            this.cropDao = cropDetail;
        }
        [HttpPost]
        public IActionResult InsertCrop(CropDetail crop)
        {
            var result = cropDao.InsertCropType(crop
                );
            return this.CreatedAtAction(
                "AddProduct",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = crop
                }
                );
        }
    }
}
