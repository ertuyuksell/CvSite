using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository DeneyimRepo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler =DeneyimRepo.list();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            DeneyimRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim t = DeneyimRepo.Find(x => x.ID == id);
            DeneyimRepo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyimlerim t = DeneyimRepo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = DeneyimRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Baslik=p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Aciklama=p.Aciklama;
            t.Tarih=p.Tarih;
            DeneyimRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}