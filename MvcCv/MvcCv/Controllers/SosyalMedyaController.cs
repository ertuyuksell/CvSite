using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        DbCvEntities db = new DbCvEntities();
        SosyalMedyaRepository SosyalMedyaRepo = new SosyalMedyaRepository();
        public ActionResult Index()
        {
            var sosyalMedya = SosyalMedyaRepo.list();
            return View(sosyalMedya);
        }
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya p)
        {
            SosyalMedyaRepo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaDuzenle(int id)
        {
            var hesap = SosyalMedyaRepo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SosyalMedyaDuzenle(TblSosyalMedya p)
        {
            var hesap = SosyalMedyaRepo.Find(x => x.ID == p.ID);
            hesap.ID = p.ID;
            hesap.Ad=p.Ad;
            hesap.Durum = true;
            hesap.Link=p.Link;
            hesap.Ikon=p.Ikon;
            SosyalMedyaRepo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            var hesap = SosyalMedyaRepo.Find(x =>x.ID == id);
            hesap.Durum = false;
            SosyalMedyaRepo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

    }
}