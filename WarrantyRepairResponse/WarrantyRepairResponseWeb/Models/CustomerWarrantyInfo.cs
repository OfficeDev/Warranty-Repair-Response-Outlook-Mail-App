using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarrantyRepairResponseWeb.Models {
    public class CustomerWarrantyInfo {
        public CustomerWarrantyInfo() {
            Products = new List<ProductWarrantyStatus>();
        }
        public string CustomerEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ProductWarrantyStatus> Products { get; set; }
    }
}