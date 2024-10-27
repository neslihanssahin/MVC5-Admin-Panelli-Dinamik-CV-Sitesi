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
        GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var mesajlar=repo.List();
            return View(mesajlar);
        }
        public ActionResult MesajSil(int id)
        {
            Tbliletisim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}