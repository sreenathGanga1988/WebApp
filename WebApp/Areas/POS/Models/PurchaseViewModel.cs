using System;
using System.Collections.Generic;
using WebApp.Repository;

namespace WebApp.Areas.POS.Models
{
    public class PurchaseViewModel
    {
        public Int32 PurchaseInvoicemasterID { get; set; }
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
        public Int32 PurchasedetailViewModelID { get; set; }
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






    public class QuotationMasterViewModel
    {
        public QuotationMasterViewModel()
        {
            QuoteNumber = (new QuotationRepository()).GetnewQuotenum();
        }
        public int QuotationMasterid { get; set; }
        public DateTime QuoteDate { get; set; }
        public DateTime QuoteRevDate { get; set; }
        public string QuoteNumber { get; set; }
        public int CustomerID { get; set; }
        public List<QuotationDetailsViewModel> QuotationDetailsViewModels { get; set; }

    }
    public class QuotationDetailsViewModel
    {

        public int QuotationDetailId { get; set; }

        public int QuotationMasterId { get; set; }
        public int CategoryID { get; set; }
        public int ItemNameID { get; set; }


        public string Specification { get; set; }
        public int Qty { get; set; }
        public Decimal TotalPrice { get; set; }


        public Decimal? UnitPrice { get; set; }
        public Decimal? SGSTPercent { get; set; }
        public Decimal? CGSTPercent { get; set; }

        public Decimal? Discount { get; set; }
        public Decimal? Gross { get; set; }





    }


}