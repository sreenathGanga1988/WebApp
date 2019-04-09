using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.DBModels
{
    interface ITrackingInfo
    {
        DateTime? AddedDate { get; set; }
        String AddedUser { get; set; }
        DateTime? Deleteddate { get; set; }
        String DeletedUser { get; set; }
        DateTime? ModifiedDate { get; set; }
        String ModifiedUser { get; set; }
        Boolean IsDeleted { get; set; }


        //public DateTime? AddedDate { get; set; }
        //public String AddedUser { get; set; }
        //public DateTime? Deleteddate { get; set; }
        //public String DeletedUser { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public String ModifiedUser { get; set; }
        //public Boolean IsDeleted { get; set; }

    }


}
