using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Areas.CustomerLoans.Models;
using WebApp.Models;
using WebApp.Models.DBModels;
using WebApp.Extensions;
namespace WebApp.API
{
    public class LoanMastersController : ApiController
    {
        private WebAppContext db = new WebAppContext();

        // GET: api/LoanMasters
        public LoanViewModelMaster GetLoanMasters()
        {
            LoanViewModelMaster mdl = new LoanViewModelMaster();
            //mdl.LoanMaster = new LoanMaster();
            return mdl;
        }



        [ResponseType(typeof(LoanMaster))]
        public LoanViewModelMaster GetLoanMaster(int id)
        {
            LoanViewModelMaster mdl = new LoanViewModelMaster();
            LoanMaster mstr = db.LoanMasters.Find(id);


            mdl.LoanID = mstr.LoanID;
            mdl.LoanName = mstr.LoanName.ToString();
            mdl.LoanDescription = mstr.LoanDescription.ToString();
            mdl.LoanAmount = mstr.LoanAmount;
            mdl.FromDate = mstr.FromDate;
            mdl.InterestPercentage = mstr.InterestPercentage;
            mdl.CustomerID = mstr.CustomerID;
            mdl.AddedDate = mstr.AddedDate ?? DateTime.Now;
            mdl.AddedUser = mstr.AddedUser;
            mdl.InOrOut = mstr.InOrOut.ToString();
            mdl.InterestType = mstr.InterestType.ToString();
            mdl.CustomerName = mstr.Customer.CustomerName;
            mdl.PhoneNumber = mstr.Customer.PhoneNumber;
            mdl.CustomerDetails = mstr.Customer.CustomerDetails;


            mdl.LastPaymentDate = null;
            mdl.LaystpaymentAmount = 0;
            mdl.BalanceAmount = 0;






            mdl.LoanPaymentDetailViewmodallist = new List<LoanPaymentDetailViewmodal>();
            DateTime? lastdate = null;
            Decimal lastpaymentamount = 0;
            Decimal Latbalance = 0;
            foreach (var element in mstr.LoanPaymentDetails.OrderBy(u => u.LoanPayDate))
            {

                LoanPaymentDetailViewmodal loandetview = new LoanPaymentDetailViewmodal();
                loandetview.LoanPayDate = element.LoanPayDate;
                loandetview.FromDate = element.FromDate;
                loandetview.ToDate = DateTime.Parse(element.ToDate.ToString()); ;
                loandetview.Days = element.Days;
                loandetview.InterestPercentage = element.InterestPercentage;
                loandetview.Interest = element.Interest;
                loandetview.TotalAmount = element.TotalAmount;
                loandetview.PaidAmount = element.PaidAmount;
                loandetview.BalanceAmount = element.BalanceAmount;
                lastdate = element.LoanPayDate;
                lastpaymentamount = element.PaidAmount;
                Latbalance = element.BalanceAmount;
                mdl.LoanPaymentDetailViewmodallist.Add(loandetview);


            }

            if (mdl.LoanPaymentDetailViewmodallist.Count == 0)
            {
                mdl.LaystpaymentAmount = 0;
                mdl.BalanceAmount = mstr.LoanAmount;
            }
            else
            {
                mdl.LaystpaymentAmount = lastpaymentamount.ZeroIfNullorEmpty();
                mdl.BalanceAmount = Latbalance.ZeroIfNullorEmpty();
                mdl.LastPaymentDate = lastdate;
            }

            //mdl.LoanMaster.
            mdl.LoanPaymentDetailViewmodal = new LoanPaymentDetailViewmodal();

            return mdl;
        }











        // PUT: api/LoanMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoanMaster(int id, LoanMaster loanMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loanMaster.LoanID)
            {
                return BadRequest();
            }

            db.Entry(loanMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LoanMasters
        [ResponseType(typeof(LoanMaster))]
        public LoanViewModelMaster PostLoanMaster(LoanViewModelMaster loanMaster)
        {


            return null;
        }






        public LoanViewModelMaster MakePayment(LoanViewModelMaster loanMaster)
        {


            //var q= from lndet1 in db.l



            //LoanPaymentDetail lpndet = new LoanPaymentDetail();

            // lpndet.LoanID=loanMaster.LoanID;
            // lpndet.LoanPayDate=loanMaster.LoanPaymentDetailViewmodal.LoanPayDate;
            // lpndet.PaidAmount=loanMaster.LoanPaymentDetailViewmodal.PaidAmount ;
            // lpndet.FromDate= DateTime.Parse (loanMaster.LastPaymentDate.ToString ());
            // lpndet.FromDate= DateTime.Parse (loanMaster.LastPaymentDate.ToString ());

            return loanMaster;
        }










        // DELETE: api/LoanMasters/5
        [ResponseType(typeof(LoanMaster))]
        public IHttpActionResult DeleteLoanMaster(int id)
        {
            LoanMaster loanMaster = db.LoanMasters.Find(id);
            if (loanMaster == null)
            {
                return NotFound();
            }

            db.LoanMasters.Remove(loanMaster);
            db.SaveChanges();

            return Ok(loanMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoanMasterExists(int id)
        {
            return db.LoanMasters.Count(e => e.LoanID == id) > 0;
        }
    }
}