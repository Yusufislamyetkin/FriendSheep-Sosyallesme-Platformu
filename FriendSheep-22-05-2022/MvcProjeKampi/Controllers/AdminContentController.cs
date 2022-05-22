using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetByHeadingPage(int id)
        {
            var whereValues = cm.GetWhereList(id);
            return View(whereValues);
        }
    }
}