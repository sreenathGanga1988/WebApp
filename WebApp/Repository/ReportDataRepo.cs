using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Areas.Reports.Models;
using WebApp.Models;

namespace WebApp.Repository
{
    public class ReportDataRepo
    {

        private WebAppContext cntxt = new WebAppContext();


        public List<Stockdata> getStockReport()
        {
            var product = (from prod in cntxt.Products
                           join purchasedetail in cntxt.PurchaseInvoiceDetails
                           on prod.PurchaseInvoiceDetailID equals purchasedetail.PurchaseInvoiceDetailID
                           join purchasmstr in cntxt.PurchaseInvoicemasters on
                           purchasedetail.PurchaseInvoicemasterID equals purchasmstr.PurchaseInvoicemasterID
                           where prod.IsDelivered == false
                           select new Stockdata
                           {
                               CategoryName = prod.Category.CategoryName,
                               ProductName = prod.ItemName.ItemDesc + "" + prod.ProductName + " " + prod.Manufacturer,

                               SerialNum = prod.SerialNum,
                               Supplier = purchasmstr.Customer.CustomerName,
                               PurchasedOn = purchasmstr.PurchaseDate,
                               SupplierInvoice = purchasmstr.PurchaseInvoiceNum,
                               UnitPrice = prod.UnitCP

                           }).ToList();

            return product;


        }

    }





}