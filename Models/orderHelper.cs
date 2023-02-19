using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNomScratch.Models
{
    public class orderHelper
    {
        public int OrderId { get; set; }
        public string Info { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public int CookID { get; set; }
        public int DeliverymanID { get; set; }
        public Nullable<int> Assign { get; set; }

    }
}