using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNomScratch.Models
{
    public class Cart
    {
        public int? Code { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
    }
}