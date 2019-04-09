using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.DBModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String ProductName { get; set; }

        public String Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public Decimal Qty { get; set; }
        public String SerialNum { get; set; }
        public Decimal TotalPrice { get; set; }
        public Decimal NonTaxCP { get; set; }
        public Decimal UnitCP { get; set; }
        public Decimal UnitSP { get; set; }
        public Decimal? UnitPrice { get; set; }
        public Decimal? DiscountForLocation { get; set; }
        public Decimal? MinimumSPForLocation { get; set; }
        public Decimal? Taxamount { get; set; }
        public Decimal? CGSTpercent { get; set; }
        public Decimal? SGSTPercent { get; set; }
        public String Color { get; set; }
        public String Image { get; set; }
        public Boolean? IsAvailable { get; set; }
        public Boolean? Isactive { get; set; }
        public Boolean? IsRateChangable { get; set; }
        public Boolean? IsTodaySpecial { get; set; }
        public int? DeliveredQty { get; set; }
        public Boolean? IsDelivered { get; set; }
        public int? PurchaseInvoiceDetailID { get; set; }
        public int? ItemNameId { get; set; }
        public int StoreID { get; set; }

        public virtual Store Store { get; set; }
        public virtual ItemName ItemName { get; set; }
        public virtual Category Category { get; set; }
    }
}