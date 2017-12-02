using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace GIS_SCM.Models
{
    public class Deliveries
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int MaterialID { get; set; }
        public int DistributionCenterID { get; set; }
        public int TransporterID { get; set; }
        public string quantity { get; set; }
        public string currentLatitude { get; set; }
        public string currentLongitude { get; set; }
        public string ETA { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Material Material { get; set; }
        public virtual Transporter Transporter { get; set; }
        public virtual DistributionCenter DistributionCenter { get; set; }


    }
}