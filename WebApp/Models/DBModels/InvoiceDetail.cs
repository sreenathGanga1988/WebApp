using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class InvoiceDetail : ITrackingInfo
    {
        [Key]
        public int InvoiceDetailID { get; set; }

        public int InvoicemasterID { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }


        [Display(Name = "InvoiceUnitPrice", Description = "Invoice Unit Price  Enters")]
        public Decimal InvoiceUnitPrice { get; set; }

        [Display(Name = "CGST %", Description = "CGST %")]
        public Decimal CGSTPercent { get; set; }

        [Display(Name = "SGST %", Description = "SGST %")]
        public Decimal SGSTPercent { get; set; }



        [Display(Name = "TotalCGSTValue ", Description = "Total CGST Value")]
        public Decimal TotalCGSTValue { get; set; }

        [Display(Name = "TotalSGSTValue ", Description = "Total SGST Value")]
        public Decimal TotalSGSTValue { get; set; }

        [Display(Name = "TotalTax ", Description = "Total Tax Including cGSTand SGST")]
        public Decimal TotalTax { get; set; }

        [Display(Name = "TotalSGSTValue ", Description = "Total Price Including tax Value")]
        public Decimal TotalPrice { get; set; }

        [Display(Name = "DisplayUnitPrice ", Description = "Price to show on invoice after Deducting tax")]
        public Decimal DisplayUnitPrice { get; set; }

        [Display(Name = "DisplayTotalPrice ", Description = "Total Price to show on invoice after Deducting tax")]
        public Decimal DisplayTotalPrice { get; set; }







        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public String DeletedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedUser { get; set; }
        public Boolean IsDeleted { get; set; }








        public Decimal UnitCGSTCP { get; set; }
        public Decimal UnitSGSTSP { get; set; }




        public virtual Product Product { get; set; }
        public virtual InvoiceMaster Invoicemaster { get; set; }

    }
}