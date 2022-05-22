using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ActivityController : Controller
    {
        ActivityManager am = new ActivityManager(new EFActivityDal());
        WriterLoginManager vlm = new WriterLoginManager(new EFWriterLoginDal());
        // GET: Activity
        public ActionResult Index(int? id)
        {
            var value = am.WhereList();

            switch (id)
            {

                case 1:
                    value = am.WhereList();
                    break;

                case 2: value = am.WhereListCity2();
                    break;
                case 3:
                    value = am.WhereListCity3();
                    break;
                case 4:
                    value = am.WhereListCity4();
                    break;
            }


            value.Reverse();
            return View(value);
        }


        [HttpGet]
        public ActionResult CreateActivity()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CreateActivity(Activity activity)
        {

            string p;
            p = (string)Session["WriterEmail"];

            var WriterValue = vlm.GetByWriterUsername(p);

            int wid = WriterValue.WriterID;

            activity.WriterID = wid;

            if (activity.activityPrice == null)
            {
                activity.activityPrice = 0;
            }

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + uzanti;

                if (yol == "~/ımage/")
                {

                }
                else
                {
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    activity.activityImage = "/ımage/" + filename + uzanti;
                }

            }

            am.Add(activity);
            TempData["AlertMessage"] = "Etkinlik Eklendi ! ";
            return RedirectToAction("CreateActivity");
        }
    }
}