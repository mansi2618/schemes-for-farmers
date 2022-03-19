using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.DataAccesslayer
{
    public interface IPlaceSellRequestDao
    {
        PlaceSellRequestDao FetchDetailsById(int id);
        List<PlaceSellRequestDao> FetchAllRequestDetails();
        bool InsertSellRequestInfo(PlaceSellRequestDao p);
    }
}
