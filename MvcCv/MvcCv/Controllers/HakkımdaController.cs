using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        DbCvEntities db = new DbCvEntities();
        HakkimdaRepository HakkımdaRepo = new HakkimdaRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkımda = HakkımdaRepo.list();
            return View(hakkımda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var t = HakkımdaRepo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            HakkımdaRepo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}