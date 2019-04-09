using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Areas.POS.Models;
using WebApp.Models;

namespace WebApp.Repository
{
    public class SalesRepo
    {





        public SalesViewModal GetSalesModel(int? id = 0)
        {
            SalesViewModal svmodel = new SalesViewModal();

            using (WebApp.Models.WebAppContext cntxt = new WebAppContext())
            {
                var q = CategoryRepo.GetCategories().Select(x => new CategoryViewModel { CategoryID = x.Id, CategoryName = x.CategoryName, Color = x.Color }).ToList();
                svmodel.CategoryViewModels = q;
            }


            if (id == 0)
            {
                svmodel.InvoiceMaster = null;
            }
            else
            {
                svmodel.InvoiceMaster = (new InvoiceRepository()).GetInvoiceMaster(id);
            }

            return svmodel;
        }


        public List<ProductListViewModel> GetProducts(int CategoryId)
        {
            List<ProductListViewModel> prdlist = new List<ProductListViewModel>();
            using (WebApp.Models.WebAppContext cntxt = new WebAppContext())
            {
                prdlist = (from prds in cntxt.Products
                           where prds.IsAvailable == true && prds.IsDelivered == false &&
                           prds.CategoryId == CategoryId
                           select new ProductListViewModel { ProductID = prds.Id, SerialNumber = prds.SerialNum, SellingPrice = prds.UnitSP, CostPrice = prds.UnitCP, ProductName = (prds.ItemName.ItemDesc ?? "") + " /" + (prds.ProductName) }).ToList();

            }
            return prdlist;
        }

        public ProductListViewModel GetProductData(int productid)
        {
            ProductListViewModel prd = new ProductListViewModel();
            using (WebApp.Models.WebAppContext cntxt = new WebAppContext())
            {
                prd = (from prds in cntxt.Products
                       where prds.IsAvailable == true && prds.IsDelivered == false &&
                       prds.Id == productid
                       select new ProductListViewModel
                       {
                           ProductID = prds.Id,
                           SerialNumber = prds.SerialNum,
                           SellingPrice = prds.UnitSP,
                           CostPrice = prds.UnitCP,
                           ProductName = (prds.ItemName.ItemDesc ?? "") + " /" + (prds.ProductName)
                       }).FirstOrDefault();

            }

            return prd;
        }




    }
}