using SchemasForFarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.BusinessAccessLayer
{
    public class ViewSoldCropHistoryModel
    {
        public ViewSoldCropHistoryModel()
        {
            User = new HashSet<UserInfo>();
        }
        public DateTime? Date { get; set; }
        public string CropName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Msp { get; set; }
        public decimal? SolidPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<UserInfo> User { get; set; }
    }
}
