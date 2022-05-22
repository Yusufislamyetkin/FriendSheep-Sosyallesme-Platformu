using BusinessLayer.Conctrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
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
    public class WriterPanelHeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager WM = new WriterManager(new EFWriterDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        // GET: WriterPanelHeading
        public ActionResult Index()
        {
            string p;
            p = (string)Session["WriterEmail"];


            List<Heading> lstH = hm.WhereListStatus(p);
            lstH.Reverse();

            List<Heading> defList = hm.WhereListDefStatus(p);
            defList.Reverse();
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

           

            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdded(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());

            string p;
            p = (string)Session["WriterEmail"];
            var session = WM.GetBySession(p);
            heading.WriterID = session.WriterID;
            hm.HeadingAdd(heading);
            TempData["AlertMessage1"] = "Başlık Paylaşıldı :)";
            return RedirectToAction("HeadingAdded");

        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            string p;
            p = (string)Session["WriterMail"];
            ViewBag.sss = p;



            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()

                                                  }


                                                 ).ToList();
            

            ViewBag.VC = valueCategory;

      

            var EditValues = hm.GetByID(id);
            return View(EditValues);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = 2;
            heading.HeadingStatus = true;
            
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