using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class PaymentModeMaster
    {
        [Key]
        public int PaymentModeID { get; set; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        [Display(Name = "Pay Mode")]
        public String PaymentMode { get; set; }
    }

}