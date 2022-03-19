using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Repository
{
    public partial class PlaceSellRequest
    {
        public string CropType { get; set; }
        public string CropName { get; set; }
        public string FertilizerType { get; set; }
        public decimal? Quantity { get; set; }
        public string SoilPhCertificate { get; set; }
        public int? UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
