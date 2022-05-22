using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DiscoverController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager catm = new CategoryManager(new EFCategoryDal());
        ContentManager com = new ContentManager(new EFContentDal());
        WriterManager vm = new WriterManager(new EFWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            var values = hm.ShowList();

           ViewBag.headingcount = values.Count();
           
            return View(values);
           
        }
     

        [HttpPost]
        public ActionResult Index(Content content)
        {
            string p;
            p = (string)Session["WriterEmail"];

            var WriterValue = vm.GetBySession(p);
            
            content.WriterID = WriterValue.WriterID;
            content.ContentDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
        
            com.ContentAdd(content);
            int id = content.HeadingID;

            return RedirectToAction("SendedPopup",new {id = id });


            
        }

        public ActionResult SendedPopup(int id)
        {

            ViewBag.id = id;
            return RedirectToAction("interactionArea", new { id = id });
        }

        [HttpGet]
        public ActionResult TimeLine()
        {
            var values = com.GetList();
            values.Reverse();
            var valuesforcontent = com.GetList();
            ViewBag.discovercontentcount = valuesforcontent.Count();

            return View(values);
        }
        public ActionResult TimeLineCat(int id)
        {

            var values = com.GetWhereListCat(id);

            ViewBag.catname = values[0].Heading.Category.CategoryName;
            values.Reverse();

            ViewBag.categoryimages = catm.GetByID(id).Categoryimages;

            var valuesforcontentvalue = com.GetWhereListCat(id);
            ViewBag.contentcount = valuesforcontentvalue.Count();

            return View(values);
        }


        [HttpGet]
       public ActionResult interactionArea(int id)
        {
            var values = hm.GetByID(id);
            ViewBag.catimage = values.Category.Categoryimages;
            ViewBag.catname = values.Category.CategoryName;
            var contentvalues = com.GetWhereList(id);
            contentvalues.Reverse();
            ViewBag.content = contentvalues;

            ViewBag.contentcount = contentvalues.Count();

            

            return View(values);

        }
   

        public ActionResult CategorySelect()
        {

            var values = catm.GetList();

         
            return View(values);
        }
      
        public ActionResult CategorySelectList(int id)
        {

            var values = hm.WhereListCategory(id);
            var valuescontent = com.GetWhereListCat(id);
            ViewBag.categoryname = catm.GetByID(id).CategoryName;
            ViewBag.categordescription = catm.GetByID(id).CategoryDescription;
            ViewBag.categoryimages = catm.GetByID(id).Categoryimages;
           


            values.Reverse();

          

            ViewBag.catname = values[0].Category.CategoryName;
            ViewBag.catıd = values[0].Category.CategoryID;

            ViewBag.contentcount = values.Count(); 
            ViewBag.headingcount = values.Count();
           

            return View(values);
        }

        public ActionResult CountryModal()
        {
            var values = hm.ShowList();


            return View(values);
        }

    }
}