using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcStokTakip.Models.Entity;
namespace MvcStokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbEnttiyUrunEntities db=new DbEnttiyUrunEntities(); 
            
        public ActionResult Index(int sayfa=1)
        {
           // var degerler=db.Tbl_Kategori.ToList();
           var degerler=db.Tbl_Kategori.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YENIKATEGORI() {
            return View();
        }
        [HttpPost]
        public ActionResult YENIKATEGORI(Tbl_Kategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YENIKATEGORI");
            }
            db.Tbl_Kategori.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(kategori); db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Tbl_Kategori.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Güncelle(Tbl_Kategori p1)
        {
            var ktgr = db.Tbl_Kategori.Find(p1.Id);
            ktgr.Ad=p1.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}