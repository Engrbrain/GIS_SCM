using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIS_SCM.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialType { get; set; }
        public string MaterialDescription { get; set; }
        public string MaterialReorder { get; set; }
    }
}