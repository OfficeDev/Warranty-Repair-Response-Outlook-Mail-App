using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WarrantyRepairResponseWeb.Controllers {
    public class CustomerResponseController : ApiController {
        // GET api/customerresponse/5
        public string Get() {
            return Get("inWarranty");
        }
        public string Get(string id) {
            string retVal = "";
            switch (id) {
                case "inWarranty":
                    retVal = "<p>Thank you for contacting Contoso Outlets. </p>" +
                                "<p>Since your product is still under warranty, you will receive a return addressed package for you to return your item <br>" +
                                "Once we receive your item, we’ll send you continual updates on the progress. </p>" +
                                "<p>Thanks you, and <b>we sincerely apologize for any shotty craftsmanship of our products and we will be happy to give you another item that will hopefully last beyond the warranty period. </b></p>" +
                                "<p>Regards,   <br>" +
                                "Your friendly customer service drone</p>";
                    break;
                case "notUnderWarranty":
                    retVal = "<p>Thank you for contacting Contoso Outlets. </p>" +
                                "<p>Unfortunately, your product is no longer under warranty. <br>" +
                                "We will be happy to inspect your item and provide you a quote for your repairs.<br>" +
                                "However, <b>our products are trendy, not reliable, so you might consider yourself lucky it's lasted this long. </b></p>" +
                                "<p>Regards,   <br>" +
                                "Your friendly customer service drone</p>";
                    break;
                default:
                    break;
            }
            return retVal;
        }

    }
}