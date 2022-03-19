using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Repository
{
    public partial class BankDetails
    {
        public int AccountNo { get; set; }
        public string Ifsccode { get; set; }
        public int Adhar { get; set; }
        public string Pan { get; set; }
        public string TraderLicense { get; set; }
        public int? UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
