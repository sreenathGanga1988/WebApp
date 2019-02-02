using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.POS.Models
{
    public class PurchaseViewModel
    {
                          
        public string SupplierInvoice { get; set; }
        public string CustomerID { get; set; }
        public DateTime SupplierInvoiceDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Decimal InvoiceValue { get; set; }
        public Decimal PaidValue { get; set; }

        public Decimal CategoryID { get; set; }
        public Decimal ItemNameId { get; set; }
      public List<PurchasedetailViewModel> purchasedetailViewModels { get; set; }
    }

    public class PurchasedetailViewModel
    {
        public string CategoryID { get; set; }
        public string ItemNameID { get; set; }
        public string ProductDetails { get; set; }
        public string Serial { get; set; }
        public string TotalQty { get; set; }
        public string TotalPrice { get; set; }
        public string CGSTPercent { get; set; }
        public string SGSTPercent { get; set; }
        public string UnitPrice { get; set; }
        public string SellingPrice { get; set; }
             

    }
}