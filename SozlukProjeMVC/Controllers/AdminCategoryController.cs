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
    public class AdminCategoryController : Controller
    {
        CategoryManagerBLL cm = new CategoryManagerBLL(new EFCategoryDAL());

        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }


        [HttpGet]
        public ActionResult AddCategory() //Sayfa üzerinde yenileme işlemi yapınca.
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p) //Kategori ekleme sayfasında post işlemi yapılınca.
        {
            CategoryValidator cv = new CategoryValidator();  //kurallarımızı dahil ettik.
            ValidationResult res = cv.Validate(p);  //kural sonuçlarımızı dahil ettik.
            if (res.IsValid)  //eğer şartlarımız doğrulanmışsa
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }

            else //şartlardan en az bir tanesi doğru değilse
            {
                foreach(var item in res.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                   
                }

                return View();
            }
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalues = cm.GetByID(id);
            cm.CategoryDelete(categoryvalues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryvalues = cm.GetByID(id);
            return View(categoryvalues);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}