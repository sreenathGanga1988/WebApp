using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models.DBModels;

namespace WebApp.Areas.CustomerLoans.Models
{
    public class LoanViewModelMaster
    {
        public System.Int32 LoanID { get; set; }
        public System.String LoanName { get; set; }
        public System.String LoanDescription { get; set; }
        public System.Decimal LoanAmount { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.Decimal InterestPercentage { get; set; }
        public System.Int32 CustomerID { get; set; }
        public System.DateTime AddedDate { get; set; }
        public System.String AddedUser { get; set; }
        public System.String InOrOut { get; set; }
        public System.String InterestType { get; set; }
        public System.String CustomerName { get; set; }
        public System.String PhoneNumber { get; set; }
        public System.String CustomerDetails { get; set; }

        public System.DateTime? LastPaymentDate { get; set; }
        public System.Decimal LaystpaymentAmount { get; set; }
        public System.Decimal BalanceAmount { get; set; }


        public LoanPaymentDetailViewmodal LoanPaymentDetailViewmodal { get; set; }

        public List<LoanPaymentDetailViewmodal> LoanPaymentDetailViewmodallist { get; set; }
    }


    public class LoanPaymentDetailViewmodal
    {
        public LoanPaymentDetailViewmodal()
        {
            this.LoanPayDate = DateTime.Now.Date;

        }

        public System.DateTime LoanPayDate { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public System.Int32 Days { get; set; }
        public System.Decimal InterestPercentage { get; set; }
        public System.Decimal Interest { get; set; }
        public System.Decimal TotalAmount { get; set; }
        public System.Decimal PaidAmount { get; set; }
        public System.Decimal BalanceAmount { get; set; }
        public System.Int32 LoanPaymentDetailID { get; set; }
        public System.Int32 LoanID { get; set; }
    }







}