using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Areas.POS.Models;
using WebApp.Models;

namespace WebApp.Repository
{
    public class Repo
    {
    }

    public class PurchaseInvoiceRepository
    {
        WebAppContext  cntxt = new WebAppContext();
        public PurchaseInvoiceMaster AddPurchaseInvoicemaster(PurchaseViewModel str)
        {
              



            PurchaseInvoiceMaster pur = new PurchaseInvoiceMaster();
            pur.CustomerID = str.CustomerID;
            pur.PurchaseInvoiceNum = str.SupplierInvoice;
            pur.PurchaseDate = str.PurchaseDate;
            pur.InvoiceDate = str.SupplierInvoiceDate;
            pur.TotalBill = str.InvoiceValue;
            pur.TotalPaid = str.InvoiceValue;
            pur.TotalDiscount = 0;
           

            pur.IsCommited = false;


            cntxt.PurchaseInvoicemasters.Add(pur);
            cntxt.SaveChanges();



            foreach ( PurchasedetailViewModel strdet in str.purchasedetailViewModels)
            {




                PurchaseInvoiceDetail purchaseInvoiceDetail = new PurchaseInvoiceDetail();

                purchaseInvoiceDetail.PurchaseInvoicemasterID = pur.PurchaseInvoicemasterID;
                purchaseInvoiceDetail.CategoryID = strdet.CategoryID;
                purchaseInvoiceDetail.ProductName = strdet.ProductDetails;
                purchaseInvoiceDetail.Qty = strdet.TotalQty;
                purchaseInvoiceDetail.SerialNum = strdet.Serial;
                purchaseInvoiceDetail.TotalPrice = strdet.TotalPrice;
                purchaseInvoiceDetail.UnitCP = strdet.UnitPrice;
                purchaseInvoiceDetail.UnitSP = strdet.SellingPrice;
                purchaseInvoiceDetail.CGSTPercent = strdet.CGSTPercent;
                purchaseInvoiceDetail.SGSTPercent = strdet.SGSTPercent;
                purchaseInvoiceDetail.NonTaxCP = strdet.UnitPrice;



                purchaseInvoiceDetail.UnitCGSTCP = 0;
                purchaseInvoiceDetail.UnitSGSTSP = 0;
                purchaseInvoiceDetail.UserID = 0;





            }







            return pur;








           

            return str;
        }

        public PurchaseViewModel UpdatePurchaseInvoicemaster(PurchaseViewModel str)
        {

            var q = from purmaster in cntxt.PurchaseInvoicemasters
                    where purmaster.PurchaseInvoicemasterID == str.PurchaseInvoicemasterID
                    select purmaster;

            foreach (var element in q)
            {


                element.CustomerID = str.CustomerID;
                element.PurchaseInvoiceNum = str.PurchaseInvoiceNum;
                element.PurchaseDate = str.PurchaseDate;
                element.InvoiceDate = str.InvoiceDate;
                element.TotalBill = str.CustomerID;

               // element.UserID = Program.UserID;
                element.IsCommited = str.IsCommited;


            }



            cntxt.SaveChanges();
            return str;
        }






        public PurchaseInvoiceDetail AddPurchaseInvoiceDetail(PurchaseInvoiceDetail str)
        {

            cntxt.PurchaseInvoiceDetails.Add(str);
            cntxt.SaveChanges();

            return str;
        }



        public PurchaseInvoiceDetail UpdatePurchaseInvoiceDetail(PurchaseInvoiceDetail str)
        {

            var q = from purmaster in cntxt.PurchaseInvoiceDetails
                    where purmaster.PurchaseInvoiceDetailID == str.PurchaseInvoiceDetailID
                    select purmaster;

            foreach (var element in q)
            {


                element.CategoryID = str.CategoryID;
                element.ProductName = str.ProductName;
                element.Qty = str.Qty;
                element.SerialNum = str.SerialNum;
                element.TotalPrice = str.TotalPrice;
                element.UnitCP = str.UnitCP;
                element.UnitSP = str.UnitSP;

                element.NonTaxCP = str.NonTaxCP;
                element.CGSTPercent = str.CGSTPercent;
                element.SGSTPercent = str.SGSTPercent;
                element.UserID = str.UserID;

            }
            cntxt.SaveChanges();
            return str;
        }




        public List<PurchaseViewModel> GetPurchaseInvoicemasterList()
        {

            var q = cntxt.PurchaseInvoicemasters.ToList();

            return q;
        }

        public PurchaseViewModel GetPurchaseInvoicemaster(int id)
        {
            var q = cntxt.PurchaseInvoicemasters.Find(id);

            return q;
        }

        public PurchaseInvoiceDetail GetPurchaseInvoiceDetails(int id)
        {
            var q = cntxt.PurchaseInvoiceDetails.Find(id);

            return q;
        }


        public PurchaseViewModel CommitAction(Boolean iscommit, int id)
        {
            PurchaseViewModel q = (from purmaster in cntxt.PurchaseInvoicemasters
                                       where purmaster.PurchaseInvoicemasterID == id
                                       select purmaster).FirstOrDefault();



            q.IsCommited = true;



            foreach (PurchaseInvoiceDetail element in q.PurchaseInvoiceDetails)
            {

                for (int i = 0; i < element.Qty; i++)
                {
                    string defaultkey = element.PurchaseInvoicemaster.PurchaseInvoicemasterID.ToString() + "-" + element.PurchaseInvoiceDetailID.ToString() + "-" + i.ToString();
                    Product product = new Product();
                    product.ProductName = element.ProductName;
                    product.CategoryId = element.CategoryID;
                    product.Qty = 1;
                    product.SerialNum = GetSerial(element.SerialNum, i, defaultkey);
                    product.NonTaxCP = element.NonTaxCP;
                    product.UnitCP = element.UnitCP;
                    product.UnitPrice = element.UnitCP;
                    product.UnitSP = element.UnitSP;
                    product.CGSTpercent = element.CGSTPercent;
                    product.SGSTPercent = element.SGSTPercent;
                    product.DiscountForLocation = 0;
                    product.MinimumSPForLocation = 0;
                    product.Taxamount = 0;
                    product.IsAvailable = true;
                    product.Isactive = true;
                    product.IsRateChangable = true;
                    product.IsTodaySpecial = true;
                    product.Color = "Red";
                    product.CGSTpercent = element.CGSTPercent;
                    product.SGSTPercent = element.SGSTPercent;
                    product.PurchaseInvoiceDetailID = element.PurchaseInvoiceDetailID;
                    cntxt.Products.Add(product);

                }
            }

            cntxt.SaveChanges();
            return q;
        }


        public string GetSerial(string serial, int num, String defaultid)
        {
            String serialdft = defaultid;
            try
            {
                String[] splitedserial = serial.Split(',');

                serialdft = splitedserial[num];

                return serialdft;
            }
            catch (Exception)
            {

                return serialdft;
            }

        }

    }


}