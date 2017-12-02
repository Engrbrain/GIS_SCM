using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class DistributionCenter
    {
        public int ID { get; set; }
        public int PlantID { get; set; }
        public string DCNumber { get; set; }
        public string DCDesc { get; set; }
        public string DCAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Plant Plant { get; set; }

        public ICollection<Deliveries> Deliveries { get; set; }
        public ICollection<InventoryByDC> InventoryByDC { get; set; }
        public ICollection<SalesSummary> SalesSummary { get; set; }
    }
}