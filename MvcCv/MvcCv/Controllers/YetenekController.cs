using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        DbCvEntities db = new DbCvEntities();
        YetenekRepository YetenekRepo = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekler = YetenekRepo.list();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            YetenekRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = YetenekRepo.Find(x => x.ID == id);
            YetenekRepo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = YetenekRepo.Find(x => x.ID == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim p)
        {
            TblYeteneklerim t = YetenekRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            YetenekRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
} 