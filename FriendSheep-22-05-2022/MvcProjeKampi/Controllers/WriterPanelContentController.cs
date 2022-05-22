using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WriterContent()
        {
            string p;
            p = (string)Session["WriterEmail"];
            var whereValues = cm.GetWhereWriterList(p);
            whereValues.Reverse();
            return View(whereValues);
        }


    }
}