using SchemasForFarmer.BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.DataAccesslayer
{
    public interface IViewmarketplace
    {
        ViewMarketPlaceDao FetchMarketDetailsById(int id);
        List<ViewMarketPlaceDao> FetchAllMarketDetails();
        bool InsertMarketPlaceInfo(ViewMarketPlaceDao p);
    }
}
