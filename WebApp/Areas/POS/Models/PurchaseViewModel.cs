using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.POS.Models
{
    public class PurchaseViewModel
    {
                          
        public string SupplierInvoice { get; set; }
        public Int32 CustomerID { get; set; }
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
        public Int32 CategoryID { get; set; }
        public Int32 ItemNameID { get; set; }
        public string ProductDetails { get; set; }
        public string Serial { get; set; }
        public Decimal TotalQty { get; set; }
        public Decimal TotalPrice { get; set; }
        public Decimal CGSTPercent { get; set; }
        public Decimal SGSTPercent { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal SellingPrice { get; set; }
             

    }
}