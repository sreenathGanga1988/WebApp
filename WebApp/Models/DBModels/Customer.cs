using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.DBModels
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Display(Name = "Customer Name")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public String CustomerName { get; set; }

        public string PhoneNumber { get; set; }
        public string CustomerDetails { get; set; }
        public String BarcodeNum { get; set; }

        public Decimal? PaymentDue { get; set; }
        public Decimal? Discount { get; set; }

        public int StoreID { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }

        public virtual Store Store { get; set; }

        public Boolean Isactive { get; set; }
    }
}