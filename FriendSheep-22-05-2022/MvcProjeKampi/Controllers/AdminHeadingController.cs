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
    public class AdminHeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager vm = new WriterManager(new EFWriterDal());


        public ActionResult Index()
        {
           
            List<Heading> lstH = hm.AdminWhereListStatus();

            List<Heading> defList = hm.AdminWhereListDefStatus();
            ViewBag.defS = defList;
            return View(lstH);
        }

        [HttpGet]
        public ActionResult HeadingAdded()
        {
            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()
                                                     
                                                  }


                                                    ).ToList();
            
            ViewBag.VC = valueCategory;

            List<SelectListItem> valueWriter = (from i in vm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.WriterName,
                                                     Value = i.WriterID.ToString()
                                                 }

                                                 ).ToList();
            ViewBag.VW = valueWriter;


            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdded(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
            
        }

        public ActionResult HeadingForWriters(int id)
        {
            List<Heading> lst = hm.WhereList(id);
            return View(lst);
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()

                                                  }


                                                 ).ToList();

            ViewBag.VC = valueCategory;

            List<SelectListItem> valueWriter = (from i in vm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = i.WriterName,
                                                    Value = i.WriterID.ToString()
                                                }

                                                 ).ToList();
            ViewBag.VW = valueWriter;

            var EditValues = hm.GetByID(id);
            return View(EditValues);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            HeadingValidatior validationRules = new HeadingValidatior();
            ValidationResult result = validationRules.Validate(heading);

            if (result.IsValid)
            {
                hm.HeadingUpdate(heading);
                return RedirectToAction("Index");
            }
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
               
            //}


            return View();



        }

        public ActionResult DeleteHeading(int id)
        {
            var findValue = hm.GetByID(id);
            hm.HeadingDelete(findValue);
            return RedirectToAction("Index");

        }

        public ActionResult ActiveHeading(int id)
        {
            var selectRow = hm.GetByID(id);
            hm.HeadingActive(selectRow);
            return RedirectToAction("Index");
        }

    }
}