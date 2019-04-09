using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class SalesMan
    {
        [Key]
        public int SalesManID { get; set; }


        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}