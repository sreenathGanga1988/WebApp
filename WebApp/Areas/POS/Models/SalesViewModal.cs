using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Models.DBModels;

namespace WebApp.Areas.POS.Models
{
    public class SalesViewModal
    {
        public List<CategoryViewModel> CategoryViewModels { get; set; }
        public InvoiceMaster InvoiceMaster { get; set; }
    }



    public class CategoryViewModel
    {
        public Int32 CategoryID { get; set; }
        public String CategoryName { get; set; }
        public String Color { get; set; }
    }



    public class ProductListViewModel
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public Decimal CostPrice { get; set; }
        public Decimal SellingPrice { get; set; }
        public String SerialNumber { get; set; }
    }






    public class InvoiceMasterViewModel
    {
        public Int32 InvoiceMasterId { get; set; }
        public Int32 PayMentModeId { get; set; }
        public Int32 CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public String InvoiceNum { get; set; }
        public String Remark { get; set; }
        public Decimal TotalBill { get; set; }
        public Decimal PaidValue { get; set; }
        public Decimal TotalDiscount { get; set; }
        public Decimal Balance { get; set; }

        public List<InvoiceDetailsViewModel> InvoiceDetails { get; set; }

    }
    public class InvoiceDetailsViewModel
    {
        public Int32 InvoiceDetailID { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 Qty { get; set; }
        public String Remark { get; set; }
        public Decimal InvoicePrice { get; set; }
        public Decimal PaidValue { get; set; }

    }

}