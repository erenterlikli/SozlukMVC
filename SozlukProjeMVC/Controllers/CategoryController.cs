using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukProjeMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManagerBLL cm = new CategoryManagerBLL(new EFCategoryDAL());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList() //kategorileri listeleme üzerine çalışacak.
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet] //Sayfa üzerinde yenileme işlemi yapınca.
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost] //Kategori ekleme sayfasında post işlemi yapılınca.
        public ActionResult AddCategory(Category p) //kategori ekleme için.
        {
            // cm.CategoryAddBLL(p);
            CategoryValidator cv = new CategoryValidator(); //kurallarımızı dahil ettik.
            ValidationResult res = cv.Validate(p); //kural sonuçlarımızı dahil ettik.

            if(res.IsValid) //eğer şartlarımız doğrulanmışsa
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");

            }

            else //şartlardan en az bir tanesi doğru değilse
            {
                foreach(var item in res.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}