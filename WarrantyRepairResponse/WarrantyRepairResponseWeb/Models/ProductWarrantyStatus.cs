using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarrantyRepairResponseWeb.Models {
    public class ProductWarrantyStatus {
        public string Name { get; set; }
        public DateTime PurchasedDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
    }
}