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
    public class AdminWriterController : Controller
    {
        WriterManager vm = new WriterManager(new EFWriterDal());

        // GET: AdminWriter
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            var ListValues = vm.GetList();
            return View(ListValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer w)
        {
            WriterValidatior Wv = new WriterValidatior();
            ValidationResult reslt = Wv.Validate(w);
            if (reslt.IsValid)
            {
                vm.WAdd(w);
                return RedirectToAction("Listing");

            }
            else
            {
                foreach (var item in reslt.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

               
            }


            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var values = vm.GetByID(id);
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


        //public ActionResult DeleteWriter(int id)
        //{
        //    var getirilendegerler = vm.GetByID(id);
        //    vm.WDelete(getirilendegerler);
        //    return RedirectToAction("Listing");

        //}
    }
}