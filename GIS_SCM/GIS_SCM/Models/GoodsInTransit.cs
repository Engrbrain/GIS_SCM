using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIS_SCM.Models
{
    public class GoodsInTransit
    {
        public int ID { get; set; }
        public int MaterialID { get; set; }
        public int GoodsMovementID { get; set; }
        public string CurrentLatitude { get; set; }
        public string CurrentLongitude { get; set; }

        public virtual Material Material { get; set; }
        public virtual GoodsMovement GoodsMovement { get; set; }

    }
}