using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class ExpenseItem
    {
        [Key]
        public int ExpenseItemID { get; set; }

        [Display(Name = "Expense Name")]
        [StringLength(450)]
        [Required]
        public String ExpenseItemName { get; set; }

        public Boolean Isactive { get; set; }
        public virtual List<ExpenseDetail> ExpenseDetails { get; set; }
    }
}