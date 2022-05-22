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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        [Authorize (Roles ="A")]
        public ActionResult Index()
        {

            var values = cm.GetList();
            return View(values);
        }

        [HttpGet]
       public ActionResult AddCategoty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategoty(Category p)
        {
            CategoryValidatior validationRules = new CategoryValidatior();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                cm.AddValue(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }


            }

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDelete(categoryValue);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = cm.GetByID(id);

            return View(categoryValue);

        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            cm.CategoryUpdate(p);

            return RedirectToAction("Index");

        }

    }
}