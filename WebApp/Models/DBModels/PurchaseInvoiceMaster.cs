using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.DBModels
{
    public class PurchaseInvoiceMaster : ITrackingInfo
    {
        [Key]
        public int PurchaseInvoicemasterID { get; set; }

        [Display(Name = "Purchase Inv#")]
        public string PurchaseInvoiceNum { get; set; }

        public int StoreID { get; set; }
        public int CustomerID { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Total Paid")]
        public Decimal TotalPaid { get; set; }

        [Display(Name = "Total Bill")]
        public Decimal TotalBill { get; set; }

        [Display(Name = "Total Discount")]
        public Decimal TotalDiscount { get; set; }

        public Decimal RoundOffAmount { get; set; }

        [Display(Name = "Commited ?")]
        public Boolean IsCommited { get; set; }
        public String CommitedBy { get; set; }
        public DateTime? CommitedDate { get; set; }

        public virtual Store Store { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }


        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public String DeletedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedUser { get; set; }
        [Display(Name = "Deleted ?")]
        public Boolean IsDeleted { get; set; }
    }
}