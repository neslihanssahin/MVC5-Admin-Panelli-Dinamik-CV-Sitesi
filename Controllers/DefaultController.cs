using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db=new DbCvEntities();
        public ActionResult Index()
        {
            var degerler=db.TblHakkimda.ToList();

            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler=db.TblDeneyimlerim.ToList();
            return PartialView( deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalarım()
        {
            var sertifikalar = db.TblSertifikalarım.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
          
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult Iletisim(Tbliletisim t)
        {
            t.Tarih=DateTime.Parse(DateTime.Now.ToString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }

    }
}