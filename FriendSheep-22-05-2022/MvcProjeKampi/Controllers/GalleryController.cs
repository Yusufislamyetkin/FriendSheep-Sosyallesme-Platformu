using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        GalleryManager gm = new GalleryManager(new EFGalleryDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var GalleryValues = gm.GalleryList();


            return View(GalleryValues);
        }
    }
}