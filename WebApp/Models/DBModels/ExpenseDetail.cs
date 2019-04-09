using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class ExpenseDetail : ITrackingInfo
    {
        [Key]
        public int ExpenseDetailID { get; set; }

        [Display(Name = "Expense Type")]
        public int ExpenseItemID { get; set; }

        [Display(Name = "Expense Cash")]
        public Decimal ExpenseValue { get; set; }

        [Display(Name = "Remark")]
        [StringLength(450)]
        [Required]
        public String ExpenseDetailRemark { get; set; }

        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }

        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }
        public DateTime? Deleteddate { get; set; }
        public String DeletedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public String ModifiedUser { get; set; }
        public Boolean IsDeleted { get; set; }
        public virtual ExpenseItem ExpenseItem { get; set; }
    }
}