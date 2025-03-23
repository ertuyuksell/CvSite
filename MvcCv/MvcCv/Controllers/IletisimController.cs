using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        DbCvEntities db = new DbCvEntities();
        IletisimRepository IletisimRepo = new IletisimRepository();
        public ActionResult Index()
        {
            var mesajlar = IletisimRepo.list();
            return View(mesajlar);
        }
    }
}