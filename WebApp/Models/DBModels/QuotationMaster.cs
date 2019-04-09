using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class QuotationMaster : ITrackingInfo
    {
        [Key]
        public int QuotationMasterid { get; set; }
        public DateTime QuoteDate { get; set; }
        public DateTime QuoteRevDate { get; set; }
        public string QuoteNumber { get; set; }
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public int StoreID { get; set; }

        public Decimal? Discount { get; set; }



        public virtual List<QuotationDetail> QuotationDetails { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        public virtual Store store { get; set; }


        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public String DeletedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedUser { get; set; }
        public Boolean IsDeleted { get; set; }



    }
}