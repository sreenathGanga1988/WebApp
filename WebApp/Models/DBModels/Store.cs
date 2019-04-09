using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.DBModels
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
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
        public virtual List<User> Users { get; set; }
        public Boolean Isactive { get; set; }
    }
}