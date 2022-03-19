using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Repository
{
    public partial class CropType
    {
        public CropType()
        {
            Sell = new HashSet<Sell>();
        }

        public int CropTypeId { get; set; }
        public string CropType1 { get; set; }

        public virtual ICollection<Sell> Sell { get; set; }
    }
}
