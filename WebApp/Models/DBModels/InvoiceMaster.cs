using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{

    public class InvoiceMaster : ITrackingInfo
    {
        public InvoiceMaster()
        {
            IsCommited = false;
        }


        [Key]
        public int InvoicemasterID { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        [Display(Name = "Invoice #")]
        public string InvoiceNum { get; set; }

        public int StoreID { get; set; }
        public int UserID { get; set; }

        public int CustomerID { get; set; }

        public int? PayMentModeId { get; set; }

        [Display(Name = "Total Tax ?")]
        public Decimal Taxamount { get; set; }

        public String Remark { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Commited ?")]
        public Boolean IsCommited { get; set; }

        [Display(Name = "Total Paid ?")]
        public Decimal TotalPaid { get; set; }
        [Display(Name = "Total Bill ?")]
        public Decimal TotalBill { get; set; }
        [Display(Name = "Discount")]
        public Decimal TotalDiscount { get; set; }

        [Display(Name = "Round Off")]
        public Decimal RoundOffAmount { get; set; }

        [Display(Name = "Balance")]
        public Decimal Balance { get; set; }

        public Boolean IsUploaded { get; set; }

        [Display(Name = "Added Date")]
        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public String DeletedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedUser { get; set; }
        public Boolean IsDeleted { get; set; }


        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }


        public virtual PaymentModeMaster PaymentModeMaster { get; set; }





    }
}