using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpGet]
        public ActionResult HakkimdaDüzenle(int id)
        {
            TblHakkimda t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult HakkimdaDüzenle(TblHakkimda p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDüzenle");
            }
            TblHakkimda t = repo.Find(x => x.ID == p.ID);
            t.Ad=p.Ad;
            t.Soyad=p.Soyad;
            t.Adres=p.Adres;
            t.Telefon=p.Telefon;
            t.Mail=p.Mail;
            t.Aciklama=p.Aciklama;
            t.Resim=p.Resim;

            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}