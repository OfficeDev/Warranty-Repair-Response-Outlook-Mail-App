/// <reference path="../App.js" />

(function () {
    'use strict';

    // The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            app.initialize();
            getCustomer();
        });
    };
    function getCustomer() {
        Office.cast.item.toItemCompose(Office.context.mailbox.item).to.getAsync(function (result) {
            var customerEmail = result.value[0].emailAddress;
            // Get the customer info from the CustomerInfo Service
            var queryURL = '../../api/CustomerInfo/?customerEmail=' + customerEmail;

            $.getJSON(queryURL, function (customerInfo) {
                // Set the Customer Name
                $('#customerName')[0].innerHTML = customerInfo.FirstName + " " + customerInfo.LastName;

                getProducts(customerInfo.Products)

            });
        });
    }
    // Iterate over the products to produce a list to select from
    // The list will contain the product name and it's warranty status 
    // which determines which email to send the customer
    function getProducts(products) {

        // Build a product HTML Table to display the list
        var $table = $('<table class="productWarrantyStatus" />');

        // Add the header
        var $headerRow = $('<tr />').appendTo($table);
        $('<th />').text("Product").appendTo($headerRow);
        $('<th />').text("Warranty End Date").appendTo($headerRow);

        // Add a row for each product, with formatting and a click event handler
        $.each(products, function (index, item) {

            // Add the row and set the style
            var $row = $('<tr />').appendTo($table);
            $row.addClass('products');

            // add the click handler for all the work to repair the item
            $row.click(function (e) {
                // use the class name to easily determine if the product is in warranty, 
                // and insert the appropriate email text
                var inWarranty = e.currentTarget.children[1].className == "inWarranty";
                insertWarrantyInfo(inWarranty);
            });
            // Creat the Product and warranty end date columns
            var $productCol = $('<td />').appendTo($row);
            var $warrantyEndCol = $('<td />').appendTo($row);

            // set the text of the two columns
            $productCol.text(products[index].Name);

            // set the style based on whether the product is under warranty
            var date = moment(products[index].WarrantyEndDate);
            $warrantyEndCol.text(date.format("MMM Do, YYYY"));
            if (date.isBefore(new moment())) {
                $warrantyEndCol.addClass('outOfWarranty')
            } else {
                $warrantyEndCol.addClass('inWarranty')
            }
        });
        // Add the products table to the products Div tag
        $table.appendTo($('#products'));
    }

    function insertWarrantyInfo(inWarranty) {
        var item = Office.context.mailbox.item;

        var responseType;
        if (inWarranty) {
            responseType = "inWarranty";
        } else {
            responseType = "notUnderWarranty";
        }
        var queryURL = '../../api/CustomerResponse/' + responseType;

        $.get(queryURL, null, function (responseText) {
            item.body.setSelectedDataAsync(responseText,
            {
                coercionType: Office.CoercionType.Html,
                asyncContext: { var3: 1, var4: 2 }
            });

        });
    }



})();