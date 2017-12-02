using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class SalesSummary
    {
        public int ID { get; set; }
        public int DistributionCenterID { get; set; }
        public string Period { get; set; }
        public string FiscalYear { get; set; }
        public float TotalSales { get; set; }

        public virtual DistributionCenter DistributionCenter { get; set; }
    }
}