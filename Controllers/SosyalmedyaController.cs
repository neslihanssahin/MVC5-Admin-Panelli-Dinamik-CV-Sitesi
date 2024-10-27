using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class SosyalmedyaController : Controller
    {
        // GET: Sosyalmedya

        GenericRepository<TblSosyalMedya> repo=new GenericRepository<TblSosyalMedya>();
        
        public ActionResult Index()
        {
            var veriler=repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult SosyalmedyaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SosyalmedyaEkle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalmedyaDüzenle(int id)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult SosyalmedyaDüzenle(TblSosyalMedya p)
        {
            if (!ModelState.IsValid)
            {
                return View(" SosyalmedyaDüzenle");
            }
            TblSosyalMedya t = repo.Find(x => x.ID == p.ID);
             t.Ad=p.Ad;
             t.Link=p.Link;
             t.ikon=p.ikon;
            t.Durum = true;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalmedyaSil(int id)
        {
            TblSosyalMedya t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

       public ActionResult SosyalmedyaDurum(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
    
            // Durumu tersine çevir
            hesap.Durum = !hesap.Durum; // Eğer durum true ise false, false ise true olur
    
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }


    }
}