using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class QuotationDetail : ITrackingInfo
    {
        [Key]
        public int QuotationDetailId { get; set; }

        public int QuotationMasterId { get; set; }
        public int CategoryID { get; set; }
        public int ItemNameID { get; set; }


        public string Specification { get; set; }
        public int Qty { get; set; }
        public Decimal TotalPrice { get; set; }


        public Decimal UnitPrice { get; set; }
        public Decimal TotalTax { get; set; }


        public Decimal? SGSTPercent { get; set; }
        public Decimal? CGSTPercent { get; set; }







        public Decimal Discount { get; set; }
        public Decimal Gross { get; set; }


        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public String DeletedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedUser { get; set; }
        public Boolean IsDeleted { get; set; }



        public virtual QuotationMaster QuotationMaster { get; set; }
        public virtual Category Category { get; set; }
        public virtual ItemName ItemName { get; set; }
    }
}