using SchemasForFarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.BusinessAccessLayer
{
    public class PlaceSellRequestModel
    {
        public PlaceSellRequestModel()
        {
            User = new HashSet<UserInfo>();
        }
        public string CropType { get; set; }
        public string CropName { get; set; }
        public string FertilizerType { get; set; }
        public decimal? Quantity { get; set; }
        public string SoilPhCertificate { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<UserInfo> User { get; set; }
    }
}
