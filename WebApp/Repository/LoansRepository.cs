using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Models.DBModels;
namespace WebApp.Repository
{


    public class LoansRepository
    {







        public void GetLoanDataofToday(int loanid)
        {



            using (WebAppContext cntxt = new WebAppContext())
            {

                LoanMaster lnmodel = cntxt.LoanMasters.Find(loanid);


                if (lnmodel != null)
                {






                }









            }



        }



    }
}