using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokTakip.Models.Entity;
namespace MvcStokTakip.Controllers
{
    public class UrunController : Controller
    {
        DbEnttiyUrunEntities db=new DbEnttiyUrunEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var deger=db.Tbl_Urun.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YENİURUN() {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.Dgr = degerler;
            return View();  



        }
        [HttpPost]
        public ActionResult YENİURUN(Tbl_Urun p1)
        {
            var ktgr=db.Tbl_Kategori.Where(m=>m.Id==p1.Tbl_Kategori.Id).FirstOrDefault();
            p1.Tbl_Kategori = ktgr;
            db.Tbl_Urun.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");  

        }
        public ActionResult SIL(int id)
        {
            var urun=db.Tbl_Urun.Find(id);  
            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Urungetir(int id)
        {
            var urun = db.Tbl_Urun.Find(id);
            List<SelectListItem> degerler = (from i in db.Tbl_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.Dgr = degerler;
            return View("Urungetir", urun);
        }
        public ActionResult Güncelle(Tbl_Urun p1)
        {
            var urn=db.Tbl_Urun.Find(p1.Urunİd);
            urn.UrunAd = p1.UrunAd;
            urn.Marka = p1.Marka;
            //  urn.Kategori = p1.Kategori;
            var ktgr = db.Tbl_Kategori.Where(m => m.Id == p1.Tbl_Kategori.Id).FirstOrDefault();
            urn.Kategori = ktgr.Id;
            urn.Fıyat = p1.Fıyat;
            urn.Stok = p1.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}