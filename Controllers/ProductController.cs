using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud_Opration_product.Data_Context;
using System.Data.Entity;

namespace Crud_Opration_product.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product_partial_view()
        {
            return View();
        }
        public ActionResult Report()
        {
            using (Db_Product_Crud_OperationEntities _Db = new Db_Product_Crud_OperationEntities())
            {
                return View(_Db.Sp_Crud().ToList());
            }

        }
        public ActionResult SaveOrUpdate(M_Product model)
        {
            int _responce;
            try
            {
                using (Db_Product_Crud_OperationEntities _Db = new Db_Product_Crud_OperationEntities())
                {
                    if (model.Product_id == 0)
                    {
                        M_Product _Product = new M_Product()
                        {
                            product_Name = model.product_Name,
                            categeory_id = model.categeory_id


                        };
                        _Db.Entry(_Product).State = EntityState.Added;
                        _responce = 1;
                    }
                    else
                    {
                        M_Product _Product = new M_Product()
                        {
                            Product_id = model.Product_id,
                            product_Name = model.product_Name


                        };
                        _Db.Entry(_Product).State = EntityState.Modified;
                        _responce = 2;
                    }

                    _Db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (_responce == 1)
            {
                TempData["message"] = "Your Data Save Successfuly..";
            }
            else if (_responce == 2)
            {
                TempData["message"] = "Your Data Update Successfuly";
            }
            else
            {
                TempData["Error"] = "Opps Somthing Wrong !!!";
            }

            return RedirectToAction("Index");
        }


    }


       



    
    
}