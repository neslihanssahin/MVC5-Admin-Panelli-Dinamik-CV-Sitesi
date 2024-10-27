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

        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();
        // GET: Yetenek
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDüzenle(int id)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult YetenekDüzenle(TblYeteneklerim p)
        {
            TblYeteneklerim t = repo.Find(x => x.ID == p.ID);
            t.Yetenek = p.Yetenek;
            t.Oran = p.Oran;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}