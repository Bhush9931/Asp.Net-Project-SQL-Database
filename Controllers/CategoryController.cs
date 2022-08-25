using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud_Opration_product.Models;
using Crud_Opration_product.Data_Context;
using System.Data.Entity;
namespace Crud_Opration_product.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category_partial_view()
        {
            return View();
        }
        public ActionResult SaveOrUpdate(Categeory_Model model)
        {
            int _responce;
            try
            {
                using (Db_Product_Crud_OperationEntities _Db = new Db_Product_Crud_OperationEntities())
                {
                    if (model.categeory_id == 0)
                    {
                        M_Categeory _Categeory = new M_Categeory()
                        {
                            categeory_Name = model.categeory_Name


                        };
                        _Db.Entry(_Categeory).State = EntityState.Added;
                        _responce = 1;
                    }
                    else
                    {
                        M_Categeory _Categeory = new M_Categeory()
                        {
                            categeory_id = model.categeory_id,
                            categeory_Name = model.categeory_Name


                        };
                        _Db.Entry(_Categeory).State = EntityState.Modified;
                        _responce =2;
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