using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class Supplier
    {

        public int ID { get; set; }
        public string SupplierNumber { get; set; }
        public string SupplierName { get; set; }
        public string Nationality { get; set; }
        public string SupplierState { get; set; }
        public string SupplierAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}