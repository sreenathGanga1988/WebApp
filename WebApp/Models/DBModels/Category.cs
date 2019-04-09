using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.DBModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public String CategoryName { get; set; }

        [Required]
        [Display(Name = "Category Color")]
        public String Color { get; set; }

        public virtual List<Product> Products { get; set; }

        public Boolean Isactive { get; set; }
    }
}