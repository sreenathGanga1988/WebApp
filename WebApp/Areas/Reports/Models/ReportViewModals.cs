using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.Reports.Models
{
    public class ReportViewModals
    {
    }

    public class Stockdata
    {
        public String CategoryName { get; set; }
        public String ProductName { get; set; }
        public String SerialNum { get; set; }
        public String Supplier { get; set; }
        public DateTime PurchasedOn { get; set; }
        public String SupplierInvoice { get; set; }
        public Decimal UnitPrice { get; set; }
        public String Status { get; set; }
        public String SalesInvoice { get; set; }
    }
}