using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string Nationality { get; set; }
        public string CustomerState { get; set; }
        public string CustomerAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ICollection<Deliveries> Deliveries { get; set; }
    }
}