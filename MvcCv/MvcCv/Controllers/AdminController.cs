using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        GenericRepository<TblAdmin> AdminRepo = new GenericRepository<TblAdmin>(); 
        // GET: Admin
        public ActionResult Index()
        {
            var liste = AdminRepo.list(); 
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            AdminRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            TblAdmin t = AdminRepo.Find(x => x.ID == id);
            AdminRepo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            TblAdmin t = AdminRepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminDuzenle(TblAdmin p)
        {
            TblAdmin t = AdminRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.KullaniciAdi=p.KullaniciAdi;
            t.Sifre=p.Sifre;    
            AdminRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
    
}