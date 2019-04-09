using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class LoanMaster
    {
        [Key]
        public int LoanID { get; set; }

        [Display(Name = "Loan Name")]
        [StringLength(450)]
        [Required]
        public String LoanName { get; set; }

        [Display(Name = "Loan Description")]
        [Required]
        public String LoanDescription { get; set; }

        [Display(Name = "Loan Amount")]
        [Required]
        public Decimal LoanAmount { get; set; }
        [Required]
        public DateTime FromDate { get; set; }

        [Display(Name = "Interest Percentage")]
        [Required]
        public Decimal InterestPercentage { get; set; }


        [Display(Name = "In or Out")]
        [Required]
        public String InOrOut { get; set; }


        [Display(Name = "Daily/Monthly")]
        [Required]
        public String InterestType { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public DateTime? AddedDate { get; set; }
        public String AddedUser { get; set; }

        public virtual List<LoanPaymentDetail> LoanPaymentDetails { get; set; }
    }
}