using System;
using System.Collections.Generic;



namespace SchemasForFarmer.Repository
{
    public partial class ApplyForPolicy
    {
        public string Season { get; set; }
        public DateTime? Year { get; set; }
        public string CropName { get; set; }
        public decimal? SumInsured { get; set; }
        public decimal? Area { get; set; }
        public string InsuranceCompany { get; set; }
        public decimal? SumInsuredperhect { get; set; }
        public decimal? SharePremium { get; set; }
        public decimal? PremiumAmount { get; set; }
        public int? PolicyNo { get; set; }

        public virtual ClaimInsurance PolicyNoNavigation { get; set; }
    }
}
