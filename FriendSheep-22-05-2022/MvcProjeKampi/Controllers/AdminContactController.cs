using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        public ActionResult Index()
        {
          var List=  cm.ContactList();
            return View(List);
        }

        public ActionResult GetContactDetail(int id)
        {
           var Cvalues = cm.ContactGetByid(id);
            return View(Cvalues);
        }

        public PartialViewResult MessageViewList()
        {
            var contactList = cm.ContactList();
            var MessageList = mm.WhereAdminMessageList();
            var NotReadedList = mm.WhereNotReadedMessageList();
            var NotReadedList2 = mm.WhereReadedMessageList();
            var trashList = mm.WhereTrushMessageList();

            int contactListCount = contactList.Count();
            int messageacount = MessageList.Count();
            int messageNotReadedacount = NotReadedList.Count();
            int messageRedadcount = NotReadedList2.Count();
            int messageTrashcount = trashList.Count();


            ViewBag.ContactMessage =contactListCount.ToString();
            ViewBag.AllMessage = messageacount.ToString(); 
            ViewBag.NotReadedMessages = messageNotReadedacount.ToString(); 
            ViewBag.ReadedMessages = messageRedadcount.ToString();
            ViewBag.TrashMessages = messageTrashcount.ToString();
            return PartialView();
        }
    }
}