using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbCvEntities db = new DbCvEntities();
        EgitimRepository EgitimRepo = new EgitimRepository();
        public ActionResult Index()
        {
            var egitim=EgitimRepo.list();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            EgitimRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = EgitimRepo.Find(x => x.ID == id);
            EgitimRepo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = EgitimRepo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim p)
        {
            TblEgitimlerim t = EgitimRepo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            EgitimRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}