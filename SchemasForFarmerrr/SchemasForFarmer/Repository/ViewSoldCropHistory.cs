using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Repository
{
    public partial class ViewSoldCropHistory
    {
        public DateTime? Date { get; set; }
        public string CropName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Msp { get; set; }
        public decimal? SolidPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
