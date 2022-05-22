using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterLoginDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {

            var writerUserInfo = wlm.GetByWriterLogin(writer);


            if (writerUserInfo != null)
            {


                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterEmail, false);

                Session["WriterEmail"] = writerUserInfo.WriterEmail;
                return RedirectToAction("CategorySelect", "Discover");


            }
            else
            {
                RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult WriterLogOut()
        {
            Session["WriterEmail"] = null;
            return RedirectToAction("Index", "HomePage");


        }
    }
}