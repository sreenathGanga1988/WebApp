using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.DBModels
{
    public class PurchaseInvoiceDetail : ITrackingInfo
    {
        [Key]
        public int PurchaseInvoiceDetailID { get; set; }

        public int PurchaseInvoicemasterID { get; set; }

        public int CategoryID { get; set; }

        public int? ItemNameId { get; set; }

        public String ProductName { get; set; }

        public Decimal Qty { get; set; }

        public String SerialNum { get; set; }

        public Decimal TotalPrice { get; set; }


        public Decimal UnitCP { get; set; }
        public Decimal UnitSP { get; set; }

        public Decimal CGSTPercent { get; set; }
        public Decimal SGSTPercent { get; set; }

        public Decimal UnitCGSTCP { get; set; }
        public Decimal UnitSGSTSP { get; set; }





        // lblUnitPrice
        public virtual List<Product> Products { get; set; }

        public int UserID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ItemName ItemName { get; set; }
        public virtual PurchaseInvoiceMaster PurchaseInvoicemaster { get; set; }



        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public String DeletedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedUser { get; set; }
        public Boolean IsDeleted { get; set; }




    }
}