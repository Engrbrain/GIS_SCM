using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIS_SCM.Models
{
    public class Transporter
    {
        public int ID { get; set; }
        public int TruckID { get; set; }
        public string TransporterNumber { get; set; }
        public string TransporterName { get; set; }
        public string Nationality { get; set; }
        public string TransporterState { get; set; }
        public string TransporterAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Truck Truck { get; set; }

        public ICollection<Deliveries> Deliveries { get; set; }
        public ICollection<GoodsMovement> GoodsMovement { get; set; }
    }
}