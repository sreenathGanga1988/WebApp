using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models.DBModels
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "User Name")]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public String UserName { get; set; }

        [Display(Name = "Pass word")]
        public String Password { get; set; }



        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }





        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }


        public DateTime ModifyDate { get; set; }
        public int ModifyUser { get; set; }

        public Boolean IsDeleted { get; set; }
        public int DeletedUser { get; set; }

        public int? StoreID { get; set; }
        public Store Store { get; set; }


    }
}