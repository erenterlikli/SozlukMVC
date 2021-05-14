using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukProjeMVC.Controllers
{
    public class StatisticsController : Controller
    {
        Context ct = new Context(); //Tablolara erişebilmek için.
      
        public ActionResult Index()
        {
            //Toplam Kategori Sayısı
            var categorytotal = ct.Categories.Count().ToString();
            ViewBag.v1 =categorytotal;

            //Yazılım Tablosundaki Toplam Başlık Sayısı
            var headingtotal = ct.Headings.Count(x => x.CategoryId == 13).ToString();
            ViewBag.v2 = headingtotal;

            //Adında "A" Harfi Geçen Yazar Sayısı
            var writeratotal = ct.Writers.Count(x => x.WriterNickname.Contains("a"));
            ViewBag.v3 = writeratotal;

            //Aktif-pasif Kategori Farkı
            var tfcategory = ct.Categories.Count(x => x.CategoryStatus == true) - ct.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.v4 = tfcategory;

            //En Fazla Başlığa Sahip Kategori
            var maxcat = ct.Categories.Where(x => x.CategoryId == (ct.Headings.GroupBy(y => y.CategoryId)
            .OrderByDescending(h => h.Count()).Select(h => h.Key).FirstOrDefault())).
            Select(y => y.CategoryName).FirstOrDefault();
            ViewBag.v5 = maxcat;

            return View();
        }

        
    }
}