using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        DbCvEntities db = new DbCvEntities();
        SertifikaRepository SertifikaRepo = new SertifikaRepository();
        public ActionResult Index()
        {
            var sertifika = SertifikaRepo.list();
            return View(sertifika);
        }


        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim p)
        {
            SertifikaRepo.TAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = SertifikaRepo.Find(x => x.ID == id);
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim p)
        {
            TblSertifikalarim t = SertifikaRepo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Aciklama = p.Aciklama;
            SertifikaRepo.TUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = SertifikaRepo.Find(x => x.ID == id);
            SertifikaRepo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}