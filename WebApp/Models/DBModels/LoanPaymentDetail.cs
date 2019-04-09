using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class LoanPaymentDetail
    {
        [Key]

        public int LoanPaymentDetailID { get; set; }

        [Display(Name = "Loan Name")]
        public int LoanID { get; set; }

        [Display(Name = "Payed On")]
        [Required]
        public DateTime LoanPayDate { get; set; }


        [Display(Name = "From Date")]
        [Required]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        [Required]
        public DateTime? ToDate { get; set; }

        [Display(Name = "Total Days")]
        [Required]
        public int Days { get; set; }


        [Display(Name = "Interest %")]
        [Required]
        public Decimal InterestPercentage { get; set; }



        [Display(Name = "Interest")]
        [Required]
        public Decimal Interest { get; set; }

        [Display(Name = "Total Amount")]
        [Required]
        public Decimal TotalAmount { get; set; }


        [Display(Name = "Paid Amount")]
        [Required]
        public Decimal PaidAmount { get; set; }



        [Display(Name = "Balance Amount")]
        [Required]
        public Decimal BalanceAmount { get; set; }


        [Required]
        public Boolean IsCurrent { get; set; }
        public virtual LoanMaster LoanMaster { get; set; }

    }
}