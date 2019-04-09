using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Areas.POS.Models;
using WebApp.Models;
using WebApp.Models.DBModels;
using WebApp.Extensions;
namespace WebApp.Repository
{
    public class Repo
    {
    }


    public static class CategoryRepo
    {
        private static WebAppContext cntxt = new WebAppContext();
        public static List<Category> GetCategories()
        {

            return cntxt.Categories.Where(u => u.Isactive == true).ToList();

        }



    }










    public class PurchaseInvoiceRepository
    {
        private WebAppContext cntxt = new WebAppContext();

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

            pur.StoreID = int.Parse(System.Web.HttpContext.Current.Session["storeid"].ToString());

            pur.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
            pur.AddedDate = DateTime.Now;
            pur.IsDeleted = false;
            pur.IsCommited = false;

            cntxt.PurchaseInvoicemasters.Add(pur);
            cntxt.SaveChanges();

            foreach (PurchasedetailViewModel strdet in str.purchasedetailViewModels)
            {
                PurchaseInvoiceDetail purchaseInvoiceDetail = new PurchaseInvoiceDetail();

                purchaseInvoiceDetail.PurchaseInvoicemasterID = pur.PurchaseInvoicemasterID;
                purchaseInvoiceDetail.CategoryID = strdet.CategoryID;
                purchaseInvoiceDetail.ItemNameId = strdet.ItemNameID;
                purchaseInvoiceDetail.ProductName = strdet.ProductDetails;
                purchaseInvoiceDetail.Qty = strdet.TotalQty;
                purchaseInvoiceDetail.SerialNum = strdet.Serial;
                purchaseInvoiceDetail.TotalPrice = strdet.TotalPrice;
                purchaseInvoiceDetail.UnitCP = strdet.UnitPrice;
                purchaseInvoiceDetail.UnitSP = strdet.SellingPrice;
                purchaseInvoiceDetail.CGSTPercent = strdet.CGSTPercent;
                purchaseInvoiceDetail.SGSTPercent = strdet.SGSTPercent;


                purchaseInvoiceDetail.UnitCGSTCP = 0;
                purchaseInvoiceDetail.UnitSGSTSP = 0;
                purchaseInvoiceDetail.UserID = 0;

                purchaseInvoiceDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                purchaseInvoiceDetail.AddedDate = DateTime.Now;
                purchaseInvoiceDetail.IsDeleted = false;

                cntxt.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail);
            }

            cntxt.SaveChanges();

            return pur;
        }

        public PurchaseViewModel UpdatePurchaseInvoicemaster(PurchaseViewModel invoicemaster)
        {
            var q = from invmstr in cntxt.PurchaseInvoicemasters
                    where invmstr.PurchaseInvoicemasterID == invoicemaster.PurchaseInvoicemasterID
                    select invmstr;

            foreach (var element in q)
            {
                element.CustomerID = invoicemaster.CustomerID;
                element.PurchaseInvoiceNum = invoicemaster.SupplierInvoice;
                element.PurchaseDate = invoicemaster.PurchaseDate;
                element.InvoiceDate = invoicemaster.SupplierInvoiceDate;
                element.TotalBill = invoicemaster.InvoiceValue;
                element.TotalPaid = invoicemaster.InvoiceValue;
                element.TotalDiscount = 0;

                element.StoreID = 1;

                element.IsCommited = false;
            }

            foreach (PurchasedetailViewModel invdet in invoicemaster.purchasedetailViewModels)
            {
                if (!cntxt.PurchaseInvoiceDetails.Any(f => f.PurchaseInvoiceDetailID == invdet.PurchasedetailViewModelID))
                {
                    PurchaseInvoiceDetail purchaseInvoiceDetail = new PurchaseInvoiceDetail();

                    purchaseInvoiceDetail.PurchaseInvoicemasterID = invoicemaster.PurchaseInvoicemasterID;
                    purchaseInvoiceDetail.CategoryID = invdet.CategoryID;
                    purchaseInvoiceDetail.ItemNameId = invdet.ItemNameID;
                    purchaseInvoiceDetail.ProductName = invdet.ProductDetails;
                    purchaseInvoiceDetail.Qty = invdet.TotalQty;
                    purchaseInvoiceDetail.SerialNum = invdet.Serial;
                    purchaseInvoiceDetail.TotalPrice = invdet.TotalPrice;
                    purchaseInvoiceDetail.UnitCP = invdet.UnitPrice;
                    purchaseInvoiceDetail.UnitSP = invdet.SellingPrice;
                    purchaseInvoiceDetail.CGSTPercent = invdet.CGSTPercent;
                    purchaseInvoiceDetail.SGSTPercent = invdet.SGSTPercent;


                    purchaseInvoiceDetail.UnitCGSTCP = 0;
                    purchaseInvoiceDetail.UnitSGSTSP = 0;
                    purchaseInvoiceDetail.UserID = 0;

                    purchaseInvoiceDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                    purchaseInvoiceDetail.AddedDate = DateTime.Now;
                    purchaseInvoiceDetail.IsDeleted = false;

                    cntxt.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail);
                }
                else
                {
                    if (invdet.PurchasedetailViewModelID != 0)
                    {
                        var q1 = from ivoidedetail in cntxt.PurchaseInvoiceDetails
                                 where ivoidedetail.PurchaseInvoiceDetailID == invdet.PurchasedetailViewModelID
                                 select ivoidedetail;
                        foreach (var element in q1)
                        {
                            element.PurchaseInvoicemasterID = invoicemaster.PurchaseInvoicemasterID;
                            element.CategoryID = invdet.CategoryID;
                            element.ItemNameId = invdet.ItemNameID;
                            element.ProductName = invdet.ProductDetails;
                            element.Qty = invdet.TotalQty;
                            element.SerialNum = invdet.Serial;
                            element.TotalPrice = invdet.TotalPrice;
                            element.UnitCP = invdet.UnitPrice;
                            element.UnitSP = invdet.SellingPrice;
                            element.CGSTPercent = invdet.CGSTPercent;
                            element.SGSTPercent = invdet.SGSTPercent;


                            element.UnitCGSTCP = 0;
                            element.UnitSGSTSP = 0;
                            element.UserID = 0;
                            element.ModifiedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                            element.ModifiedDate = DateTime.Now;
                        }
                    }
                    else
                    {
                        PurchaseInvoiceDetail purchaseInvoiceDetail = new PurchaseInvoiceDetail();

                        purchaseInvoiceDetail.PurchaseInvoicemasterID = invoicemaster.PurchaseInvoicemasterID;
                        purchaseInvoiceDetail.CategoryID = invdet.CategoryID;
                        purchaseInvoiceDetail.ItemNameId = invdet.ItemNameID;
                        purchaseInvoiceDetail.ProductName = invdet.ProductDetails;
                        purchaseInvoiceDetail.Qty = invdet.TotalQty;
                        purchaseInvoiceDetail.SerialNum = invdet.Serial;
                        purchaseInvoiceDetail.TotalPrice = invdet.TotalPrice;
                        purchaseInvoiceDetail.UnitCP = invdet.UnitPrice;
                        purchaseInvoiceDetail.UnitSP = invdet.SellingPrice;
                        purchaseInvoiceDetail.CGSTPercent = invdet.CGSTPercent;
                        purchaseInvoiceDetail.SGSTPercent = invdet.SGSTPercent;


                        purchaseInvoiceDetail.UnitCGSTCP = 0;
                        purchaseInvoiceDetail.UnitSGSTSP = 0;
                        purchaseInvoiceDetail.UserID = 0;

                        purchaseInvoiceDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                        purchaseInvoiceDetail.AddedDate = DateTime.Now;
                        purchaseInvoiceDetail.IsDeleted = false;
                        cntxt.PurchaseInvoiceDetails.Add(purchaseInvoiceDetail);
                    }
                }
            }

            var alreadyenteredinvoicelist = from ivoidedetail in cntxt.PurchaseInvoiceDetails
                                            where ivoidedetail.PurchaseInvoicemasterID == invoicemaster.PurchaseInvoicemasterID && ivoidedetail.PurchaseInvoiceDetailID != 0
                                            select ivoidedetail;

            foreach (var element in alreadyenteredinvoicelist)
            {
                //if (!Quotmater.InvoiceDetails.Any(f => f.InvoiceDetailID == element.InvoiceDetailID))
                if (!invoicemaster.purchasedetailViewModels.Any(f => f.PurchasedetailViewModelID == element.PurchaseInvoiceDetailID))
                {
                    element.IsDeleted = true;
                    element.DeletedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                    element.Deleteddate = DateTime.Now;
                    element.Qty = 0;
                }
            }

            cntxt.SaveChanges();

            return invoicemaster;
        }

        public PurchaseViewModel GetPurchaseViewModal(int id)
        {
            PurchaseViewModel purchaseviewNodal = new PurchaseViewModel();
            PurchaseInvoiceMaster invmstr = GetPurchaseInvoicemaster(id);

            purchaseviewNodal.SupplierInvoice = invmstr.PurchaseInvoiceNum;
            purchaseviewNodal.SupplierInvoiceDate = invmstr.InvoiceDate;
            purchaseviewNodal.PurchaseDate = invmstr.PurchaseDate;
            purchaseviewNodal.CustomerID = invmstr.CustomerID;
            purchaseviewNodal.InvoiceValue = invmstr.TotalBill;
            purchaseviewNodal.PaidValue = invmstr.TotalPaid;

            //foreach (PurchaseInvoiceDetail in  invmstr.PurchaseInvoiceDetails ){
            //}

            return purchaseviewNodal;
        }

        public List<PurchaseInvoiceMaster> GetPurchaseInvoicemasterList()
        {
            var q = cntxt.PurchaseInvoicemasters.ToList();

            return q;
        }

        public PurchaseInvoiceMaster GetPurchaseInvoicemaster(int id)
        {
            var q = cntxt.PurchaseInvoicemasters.Find(id);

            return q;
        }

        public PurchaseInvoiceDetail GetPurchaseInvoiceDetails(int id)
        {
            var q = cntxt.PurchaseInvoiceDetails.Find(id);

            return q;
        }

        public PurchaseInvoiceMaster CommitAction(Boolean iscommit, int id)
        {
            PurchaseInvoiceMaster q = (from purmaster in cntxt.PurchaseInvoicemasters
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
                    product.ItemNameId = element.ItemNameId;
                    product.Qty = 1;
                    product.SerialNum = GetSerial(element.SerialNum, i, defaultkey);
                    product.NonTaxCP = element.UnitCP;
                    product.UnitCP = element.UnitCP;
                    product.UnitPrice = element.UnitCP;
                    product.UnitSP = element.UnitSP;
                    product.CGSTpercent = element.CGSTPercent;
                    product.SGSTPercent = element.SGSTPercent;
                    product.DiscountForLocation = 0;
                    product.MinimumSPForLocation = 0;
                    product.Taxamount = 0;
                    product.IsDelivered = false;
                    product.IsAvailable = true;
                    product.Isactive = true;
                    product.IsRateChangable = true;
                    product.IsTodaySpecial = true;
                    product.Color = "Red";
                    product.StoreID = int.Parse(System.Web.HttpContext.Current.Session["storeid"].ToString());
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

    public class QuotationRepository
    {
        private WebAppContext cntxt = new WebAppContext();

        public QuotationMasterViewModel AddQuotationMaster(QuotationMasterViewModel str)
        {
            QuotationMaster pur = new QuotationMaster();
            pur.CustomerID = str.CustomerID;
            pur.QuoteNumber = str.QuoteNumber;
            pur.QuoteDate = str.QuoteDate;
            pur.QuoteRevDate = str.QuoteRevDate;

            pur.StoreID = int.Parse(System.Web.HttpContext.Current.Session["storeid"].ToString());
            pur.UserID = int.Parse(System.Web.HttpContext.Current.Session["userid"].ToString());
            pur.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
            cntxt.QuotationMasters.Add(pur);
            cntxt.SaveChanges();

            foreach (QuotationDetailsViewModel strdet in str.QuotationDetailsViewModels)
            {
                QuotationDetail quotationDetail = new QuotationDetail();

                quotationDetail.QuotationMasterId = pur.QuotationMasterid;
                quotationDetail.CategoryID = strdet.CategoryID;
                quotationDetail.ItemNameID = strdet.ItemNameID;
                quotationDetail.Specification = strdet.Specification;
                quotationDetail.Qty = strdet.Qty;
                quotationDetail.TotalPrice = strdet.TotalPrice;
                quotationDetail.UnitPrice = strdet.UnitPrice ?? 00;

                quotationDetail.CGSTPercent = strdet.CGSTPercent;
                quotationDetail.SGSTPercent = strdet.SGSTPercent;
                quotationDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                quotationDetail.AddedDate = DateTime.Now;
                quotationDetail.IsDeleted = false;
                cntxt.QuotationDetails.Add(quotationDetail);
            }

            cntxt.SaveChanges();

            return str;
        }

        public QuotationMasterViewModel UpdateQuotationMaster(QuotationMasterViewModel Quotmater)
        {
            var q = from invmstr in cntxt.QuotationMasters
                    where invmstr.QuotationMasterid == Quotmater.QuotationMasterid
                    select invmstr;

            foreach (var element in q)
            {
                element.CustomerID = Quotmater.CustomerID;
                element.QuoteNumber = Quotmater.QuoteNumber;
                element.QuoteDate = Quotmater.QuoteDate;
                element.QuoteRevDate = Quotmater.QuoteRevDate;
                element.ModifiedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                element.ModifiedDate = DateTime.Now;
            }

            foreach (QuotationDetailsViewModel Quotdet in Quotmater.QuotationDetailsViewModels)
            {
                if (!cntxt.QuotationDetails.Any(f => f.QuotationDetailId == Quotdet.QuotationDetailId))
                {
                    QuotationDetail quotationDetail = new QuotationDetail();

                    quotationDetail.QuotationMasterId = Quotmater.QuotationMasterid;
                    quotationDetail.CategoryID = Quotdet.CategoryID;
                    quotationDetail.ItemNameID = Quotdet.ItemNameID;
                    quotationDetail.Specification = Quotdet.Specification;
                    quotationDetail.Qty = Quotdet.Qty;
                    quotationDetail.TotalPrice = Quotdet.TotalPrice;
                    quotationDetail.UnitPrice = Quotdet.UnitPrice ?? 00;

                    quotationDetail.CGSTPercent = Quotdet.CGSTPercent;
                    quotationDetail.SGSTPercent = Quotdet.SGSTPercent;
                    quotationDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                    quotationDetail.AddedDate = DateTime.Now;
                    quotationDetail.IsDeleted = false;
                    cntxt.QuotationDetails.Add(quotationDetail);
                }
                else
                {
                    if (Quotdet.QuotationDetailId != 0)
                    {
                        var q1 = from ivoidedetail in cntxt.QuotationDetails
                                 where ivoidedetail.QuotationDetailId == Quotdet.QuotationDetailId
                                 select ivoidedetail;
                        foreach (var element in q1)
                        {
                            element.CategoryID = Quotdet.CategoryID;
                            element.ItemNameID = Quotdet.ItemNameID;
                            element.Specification = Quotdet.Specification;
                            element.Qty = Quotdet.Qty;
                            element.TotalPrice = Quotdet.TotalPrice;
                            element.UnitPrice = Quotdet.UnitPrice ?? 00;

                            element.CGSTPercent = Quotdet.CGSTPercent;
                            element.SGSTPercent = Quotdet.SGSTPercent;

                            element.ModifiedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                            element.ModifiedDate = DateTime.Now;
                        }
                    }
                    else
                    {
                        QuotationDetail quotationDetail = new QuotationDetail();

                        quotationDetail.QuotationMasterId = Quotmater.QuotationMasterid;
                        quotationDetail.CategoryID = Quotdet.CategoryID;
                        quotationDetail.ItemNameID = Quotdet.ItemNameID;
                        quotationDetail.Specification = Quotdet.Specification;
                        quotationDetail.Qty = Quotdet.Qty;
                        quotationDetail.TotalPrice = Quotdet.TotalPrice;
                        quotationDetail.UnitPrice = Quotdet.UnitPrice ?? 00;

                        quotationDetail.CGSTPercent = Quotdet.CGSTPercent;
                        quotationDetail.SGSTPercent = Quotdet.SGSTPercent;


                        quotationDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                        quotationDetail.AddedDate = DateTime.Now;
                        quotationDetail.IsDeleted = false;

                        cntxt.QuotationDetails.Add(quotationDetail);
                    }
                }
            }

            var alreadyenteredinvoicelist = from ivoidedetail in cntxt.QuotationDetails
                                            where ivoidedetail.QuotationMasterId == Quotmater.QuotationMasterid && ivoidedetail.QuotationDetailId != 0
                                            select ivoidedetail;

            foreach (var element in alreadyenteredinvoicelist)
            {
                //if (!Quotmater.InvoiceDetails.Any(f => f.InvoiceDetailID == element.InvoiceDetailID))
                if (!Quotmater.QuotationDetailsViewModels.Any(f => f.QuotationDetailId == element.QuotationDetailId))
                {
                    element.IsDeleted = true;
                    element.DeletedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                    element.Deleteddate = DateTime.Now;
                    element.Qty = 0;
                }
            }

            cntxt.SaveChanges();

            return Quotmater;
        }

        public QuotationMaster GetQuotationMaster(int id)
        {
            var q = cntxt.QuotationMasters.Find(id);

            return q;
        }

        public List<QuotationMaster> GetQuotationListAsync()
        {
            var q = cntxt.QuotationMasters.OrderByDescending(u => u.QuotationMasterid);

            return q.ToList();
        }


        public string GetnewQuotenum()
        {
            var q = cntxt.QuotationMasters.Select(p => p.QuotationMasterid).DefaultIfEmpty(0).Max();
            return "QT_" + (q + 1);

        }

    }




    public class InvoiceRepository
    {
        private WebAppContext cntxt = new WebAppContext();

        public InvoiceMasterViewModel AddinvoiceMaster(InvoiceMasterViewModel str)
        {
            InvoiceMaster pur = new InvoiceMaster();
            pur.CustomerID = str.CustomerID;
            pur.PayMentModeId = str.PayMentModeId;
            pur.InvoiceDate = str.InvoiceDate;
            pur.Remark = (str.Remark + "").Trim();
            pur.TotalBill = str.TotalBill.ZeroIfNullorEmpty();
            pur.TotalPaid = str.PaidValue.ZeroIfNullorEmpty();
            pur.TotalDiscount = str.TotalDiscount.ZeroIfNullorEmpty();
            pur.Balance = str.Balance.ZeroIfNullorEmpty();
            pur.StoreID = int.Parse(System.Web.HttpContext.Current.Session["storeid"].ToString());
            pur.UserID = int.Parse(System.Web.HttpContext.Current.Session["userid"].ToString());
            pur.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
            pur.AddedDate = DateTime.Now;
            pur.IsCommited = false;
            pur.IsDeleted = false;
            cntxt.InvoiceMasters.Add(pur);
            cntxt.SaveChanges();

            pur.InvoiceNum = "HST" + pur.InvoicemasterID.ToString().PadLeft(4, '0');
            str.InvoiceMasterId = pur.InvoicemasterID;
            str.InvoiceNum = pur.InvoiceNum;
            foreach (InvoiceDetailsViewModel strdet in str.InvoiceDetails)
            {
                Product p = cntxt.Products.Find(strdet.ProductId);


                InvoiceDetail quotationDetail = new InvoiceDetail();

                quotationDetail.InvoicemasterID = pur.InvoicemasterID;
                quotationDetail.ProductId = strdet.ProductId;
                quotationDetail.Qty = strdet.Qty;


                quotationDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                quotationDetail.AddedDate = DateTime.Now;
                quotationDetail.IsDeleted = false;

                quotationDetail.InvoiceUnitPrice = strdet.InvoicePrice;
                quotationDetail.TotalPrice = strdet.InvoicePrice * strdet.Qty;

                quotationDetail.CGSTPercent = Decimal.Parse(p.CGSTpercent.ToString()).ZeroIfNullorEmpty();
                quotationDetail.TotalCGSTValue = calculateGST(quotationDetail.CGSTPercent, quotationDetail.TotalPrice);

                quotationDetail.SGSTPercent = Decimal.Parse(p.SGSTPercent.ToString()).ZeroIfNullorEmpty();
                quotationDetail.TotalSGSTValue = calculateGST(quotationDetail.SGSTPercent, quotationDetail.TotalPrice);


                quotationDetail.DisplayTotalPrice = quotationDetail.TotalPrice - (quotationDetail.TotalCGSTValue + quotationDetail.TotalSGSTValue);

                quotationDetail.DisplayUnitPrice = quotationDetail.DisplayTotalPrice / quotationDetail.Qty;



                quotationDetail.TotalTax = quotationDetail.TotalCGSTValue + quotationDetail.TotalSGSTValue;






                cntxt.InvoiceDetails.Add(quotationDetail);


                p.IsAvailable = false;

            }

            cntxt.SaveChanges();

            return str;
        }

        public Decimal calculateGST(Decimal percent, Decimal Amount)
        {
            Decimal val = (percent / 100) * Amount;
            return val;
        }

        public InvoiceMasterViewModel UpdateInvoiceMaster(InvoiceMasterViewModel Quotmater)
        {
            var q = from invmstr in cntxt.InvoiceMasters
                    where invmstr.InvoicemasterID == Quotmater.InvoiceMasterId
                    select invmstr;

            foreach (var element in q)
            {
                element.CustomerID = Quotmater.CustomerID;
                element.PayMentModeId = Quotmater.PayMentModeId;
                element.InvoiceDate = Quotmater.InvoiceDate;
                element.Remark = Quotmater.Remark;
                element.TotalBill = Quotmater.TotalBill;
                element.TotalPaid = Quotmater.PaidValue;
                element.TotalDiscount = Quotmater.TotalDiscount;
            }

            foreach (InvoiceDetailsViewModel invoicedet in Quotmater.InvoiceDetails)
            {
                if (!cntxt.InvoiceDetails.Any(f => f.InvoiceDetailID == invoicedet.InvoiceDetailID))
                {
                    InvoiceDetail quotationDetail = new InvoiceDetail();

                    quotationDetail.InvoicemasterID = Quotmater.InvoiceMasterId;
                    quotationDetail.ProductId = invoicedet.ProductId;
                    quotationDetail.Qty = invoicedet.Qty;
                    quotationDetail.TotalPrice = invoicedet.InvoicePrice;

                    quotationDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                    quotationDetail.AddedDate = DateTime.Now;
                    quotationDetail.IsDeleted = false;



                    cntxt.InvoiceDetails.Add(quotationDetail);
                }
                else
                {
                    if (invoicedet.InvoiceDetailID != 0)
                    {
                        var q1 = from ivoidedetail in cntxt.InvoiceDetails
                                 where ivoidedetail.InvoiceDetailID == invoicedet.InvoiceDetailID
                                 select ivoidedetail;
                        foreach (var element in q1)
                        {
                            element.ProductId = invoicedet.ProductId;
                            element.Qty = invoicedet.Qty;
                            element.TotalPrice = invoicedet.InvoicePrice;

                            element.ModifiedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                            element.ModifiedDate = DateTime.Now;
                            element.IsDeleted = false;
                        }
                    }
                    else
                    {
                        InvoiceDetail quotationDetail = new InvoiceDetail();

                        quotationDetail.InvoicemasterID = Quotmater.InvoiceMasterId;
                        quotationDetail.ProductId = invoicedet.ProductId;
                        quotationDetail.Qty = invoicedet.Qty;
                        quotationDetail.TotalPrice = invoicedet.InvoicePrice;

                        quotationDetail.AddedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                        quotationDetail.AddedDate = DateTime.Now;
                        quotationDetail.IsDeleted = false;



                        cntxt.InvoiceDetails.Add(quotationDetail);
                    }
                }
            }

            var alreadyenteredinvoicelist = from ivoidedetail in cntxt.InvoiceDetails
                                            where ivoidedetail.InvoicemasterID == Quotmater.InvoiceMasterId && ivoidedetail.InvoiceDetailID != 0
                                            select ivoidedetail;

            foreach (var element in alreadyenteredinvoicelist)
            {
                //if (!Quotmater.InvoiceDetails.Any(f => f.InvoiceDetailID == element.InvoiceDetailID))
                if (!Quotmater.InvoiceDetails.Any(f => f.InvoiceDetailID == element.InvoiceDetailID))
                {
                    element.IsDeleted = true;
                    element.DeletedUser = System.Web.HttpContext.Current.Session["username"].ToString();
                    element.Deleteddate = DateTime.Now;
                    element.Qty = 0;
                }
            }

            cntxt.SaveChanges();

            return Quotmater;
        }

        public InvoiceMaster GetInvoiceMaster(int? id = 0)
        {
            var q = cntxt.InvoiceMasters.Find(id);

            return q;
        }

        public List<QuotationMaster> GetQuotationListAsync()
        {
            var q = cntxt.QuotationMasters.ToList();

            return q;
        }


        public InvoiceMaster CommitAction(Boolean iscommit, int id)
        {
            InvoiceMaster q = (from invmstr in cntxt.InvoiceMasters
                               where invmstr.InvoicemasterID == id
                               select invmstr).FirstOrDefault();

            q.IsCommited = true;

            foreach (InvoiceDetail element in q.InvoiceDetails.ToList())
            {
                Product p = cntxt.Products.Find(element.ProductId);

                p.IsDelivered = true;
                p.IsAvailable = false;
                p.DeliveredQty = element.Qty;

            }

            cntxt.SaveChanges();
            return q;
        }



    }





}