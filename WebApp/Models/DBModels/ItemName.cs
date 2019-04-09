using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.DBModels
{
    public class ItemName
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Item Desc")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public String ItemDesc { get; set; }

        public int CategoryId { get; set; }
        public Boolean Isactive { get; set; }



        public virtual Category Category { get; set; }


        public virtual List<Product> Products { get; set; }
        public virtual List<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }

    }
}