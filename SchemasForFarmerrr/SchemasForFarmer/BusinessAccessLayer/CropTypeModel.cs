using SchemasForFarmer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemasForFarmer.BusinessAccessLayer
{
    public class CropTypeModel
    {
        public CropTypeModel()
        {
            Sell = new HashSet<Sell>();
        }

        public int CropTypeId { get; set; }
        public string CropType1 { get; set; }

        public virtual ICollection<Sell> Sell { get; set; }
    }
}
