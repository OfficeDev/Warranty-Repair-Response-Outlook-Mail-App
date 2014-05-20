using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WarrantyRepairResponseWeb.Controllers {
    public class CustomerInfoController : ApiController {
        public Models.CustomerWarrantyInfo Get(string customerEmail) {
            Models.CustomerWarrantyInfo retVal = new Models.CustomerWarrantyInfo();
            #region Call our CRM system
            retVal.FirstName = "Steve";
            retVal.LastName = "Lasker";
            retVal.CustomerEmail = "SteveLas@microsoft.com";
            TimeSpan purchaseDate = new TimeSpan(700, 0, 0, 0);
            retVal.Products.Add(
                new Models.ProductWarrantyStatus() {
                    Name = "Aeroflite Three-Hand Watch",
                    PurchasedDate = DateTime.Now.Subtract(purchaseDate),
                    WarrantyEndDate = DateTime.Now.Subtract(purchaseDate).AddYears(3)
                });
            retVal.Products.Add(
                new Models.ProductWarrantyStatus() {
                    Name = "Topaz Necklace",
                    PurchasedDate = DateTime.Now.Subtract(purchaseDate).AddDays(200),
                    WarrantyEndDate = DateTime.Now.Subtract(purchaseDate).AddDays(200).AddYears(1)
                });
            retVal.Products.Add(
                new Models.ProductWarrantyStatus() {
                    Name = "Tesla Model S",
                    PurchasedDate = DateTime.Now.Subtract(purchaseDate).AddDays(500),
                    WarrantyEndDate = DateTime.Now.Subtract(purchaseDate).AddDays(500).AddYears(5)
                });
            #endregion
            return retVal;
        }
    }
}