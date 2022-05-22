using BusinessLayer.Conctrete;
using DataAccesLayer.Concrete;
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
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EFAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var adminUserInfo = am.GetByAdminLogin(admin);
            

            if (adminUserInfo != null)
            {
              

                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminName, false);
                
                Session["AdminName"] = adminUserInfo.AdminName;
                return RedirectToAction("Index", "AdminWelcomePage");


            }
            else
            {
                RedirectToAction("Index");
            }

            return View();
        }


       
       
    }
}