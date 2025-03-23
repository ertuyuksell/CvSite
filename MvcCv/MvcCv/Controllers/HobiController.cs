using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        DbCvEntities db = new DbCvEntities();
        HobiRepository HobiRepo = new HobiRepository();
        public ActionResult Index()
        {
            var hobiler = HobiRepo.list();
            return View(hobiler);
        }

        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim p)
        {
            HobiRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            var hobiler = HobiRepo.Find(x => x.ID == id);
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult HobiGetir(TblHobilerim p)
        {
            TblHobilerim t = HobiRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Aciklama1 = p.Aciklama1;
            HobiRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}