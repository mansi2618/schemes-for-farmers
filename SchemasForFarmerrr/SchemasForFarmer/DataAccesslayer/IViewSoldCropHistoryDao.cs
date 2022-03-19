using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.DataAccesslayer
{
    interface IViewSoldCropHistoryDao
    {
        ViewSoldCropHistoryDao FetchHistoryById(int id);
        List<ViewSoldCropHistoryDao> FetchAllHistoryDetails();
        bool InsertCropHistoryInfo(ViewSoldCropHistoryDao p);
    }
}
