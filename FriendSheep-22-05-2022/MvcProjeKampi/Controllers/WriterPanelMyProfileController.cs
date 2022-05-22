using BusinessLayer.Conctrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMyProfileController : Controller
    {
        WriterManager vm = new WriterManager(new EFWriterDal());

        [HttpGet]
        public ActionResult EditWriter()
        {
            string p;
            p = (string)Session["WriterEmail"];
            var values = vm.GetBySession(p);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer w)
        {
            WriterValidatior Wv = new WriterValidatior();
            ValidationResult reslt = Wv.Validate(w);

            if (reslt.IsValid)
            {
                vm.WUpdate(w);
                return RedirectToAction("Listing");
            }
            else
            {
                foreach (var item in reslt.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
                return View();
            }



        }
    }
}