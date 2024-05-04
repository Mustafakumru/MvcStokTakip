using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;

namespace MvcStokTakip.Controllers
{
    public class MusteriController : Controller
    {
        DbEnttiyUrunEntities db=new DbEnttiyUrunEntities();
        // GET: Musteri
        public ActionResult Index()
        {
            var deger = db.Tbl_Musterı.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YENİMUSTERİ() {
            return View();
         }
        [HttpPost]
        public ActionResult YENİMUSTERİ(Tbl_Musterı p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YENİMUSTERİ");
            }
            db.Tbl_Musterı.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri=db.Tbl_Musterı.Find(id);
            db.Tbl_Musterı.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Tbl_Musterı.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Güncelle(Tbl_Musterı p1)
        {
            var Musterı = db.Tbl_Musterı.Find(p1.Musteriİd);
            Musterı.MusteriAd = p1.MusteriAd;
            Musterı.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
