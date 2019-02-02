using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{


    public class Store
    {

        [Key]
        public int StoreID { get; set; }
        [Display(Name = "Store Name")]
        public String StoreName { get; set; }

        [Display(Name = "Store Address")]
        public String StoreAddress { get; set; }

        [Display(Name = "Store Street")]
        public String Street { get; set; }
        public String Phone { get; set; }

        [Display(Name = "Store Tax Id")]
        public String StoreTaxId { get; set; }
        public virtual List<Product> Products { get; set; }

        public Boolean? Isactive { get; set; }

    }






    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        public String CategoryName { get; set; }
        [Required]
        [Display(Name = "Category Color")]
        public String Color { get; set; }
        public virtual List<Product> Products { get; set; }

        public Boolean? Isactive { get; set; }
    }

    public class ItemName
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Item Desc")]
        public string ItemDesc { get; set; }
        public virtual List<Product> Products { get; set; }

        public Boolean? Isactive { get; set; }
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }



        [Required]
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
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




    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }


        [Display(Name = "Customer Name")]
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

        public Boolean? Isactive { get; set; }

    }

    public class PurchaseInvoiceMaster
    {

        [Key]
        public int PurchaseInvoicemasterID { get; set; }

        [Display(Name = "Purchase Inv#")]
        public string PurchaseInvoiceNum { get; set; }

        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        [Display(Name = "Invoice Date#")]
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Purchase Date#")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Total Paid#")]
        public Decimal TotalPaid { get; set; }
        [Display(Name = "Total Bill#")]
        public Decimal TotalBill { get; set; }
        [Display(Name = "Total Discount#")]
        public Decimal TotalDiscount { get; set; }
        public Decimal RoundOffAmount { get; set; }

        public Boolean? IsCommited { get; set; }

        public virtual Store Store { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }

        public Boolean? IsDeleted { get; set; }
        public String DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]
        public string CustomerAdress { get; set; }

        [NotMapped]
        public string CustomerPhone { get; set; }


    }
    public class PurchaseInvoiceDetail
    {

        [Key]
        public int PurchaseInvoiceDetailID { get; set; }
        public int PurchaseInvoicemasterID { get; set; }

        public int CategoryID { get; set; }

        public String ProductName { get; set; }

        public Decimal Qty { get; set; }

        public String SerialNum { get; set; }

        public Decimal TotalPrice { get; set; }

        public Decimal NonTaxCP { get; set; }
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
        public virtual PurchaseInvoiceMaster PurchaseInvoicemaster { get; set; }

    }



}