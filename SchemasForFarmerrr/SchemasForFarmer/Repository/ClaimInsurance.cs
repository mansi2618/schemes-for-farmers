﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchemasForFarmer.Repository
{
    public partial class ClaimInsurance
    {
        public ClaimInsurance()
        {
            ApplyForPolicy = new HashSet<ApplyForPolicy>();
        }

        public string ParticularsOfInsuree { get; set; }
        public int PolicyNo { get; set; }
        public string InsuranceCompany { get; set; }
        public string NameOfInsuree { get; set; }
        public decimal? SumInsured { get; set; }
        public string CauseOfLoss { get; set; }
        public DateTime? DateOfLoss { get; set; }

        public virtual ICollection<ApplyForPolicy> ApplyForPolicy { get; set; }
    }
}
