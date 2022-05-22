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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());

        public ActionResult Index()
        {
            var MessageList = mm.WhereAdminMessageList();


            return View(MessageList);
        }

        public ActionResult NotReadedList()
        {
            var NotReadedList = mm.WhereNotReadedMessageList();
            return View(NotReadedList);
        }
        public ActionResult ReadedList()
        {
            var NotReadedList2 = mm.WhereReadedMessageList();
            return View(NotReadedList2);
        }


        public ActionResult MoveTrashIndex(int id)
        {
            var deleteValue = mm.MessageGetById(id);
            deleteValue.MessageDeletedStatus = true;
            mm.MessageUpdate(deleteValue);
            return RedirectToAction("Index");
        }
        public ActionResult MoveTrashReaded(int id)
        {
            var deleteValue = mm.MessageGetById(id);
            deleteValue.MessageDeletedStatus = true;
            mm.MessageUpdate(deleteValue);
            return RedirectToAction("ReadedList");
        }
        public ActionResult MoveTrashNotReaded(int id)
        {
            var deleteValue = mm.MessageGetById(id);
            deleteValue.MessageDeletedStatus = true;
            mm.MessageUpdate(deleteValue);
            return RedirectToAction("NotReadedList");
        }
        public ActionResult OutTheTrash(int id)
        {
            var deleteValue = mm.MessageGetById(id);
            deleteValue.MessageDeletedStatus = false;
            mm.MessageUpdate(deleteValue);
            return RedirectToAction("TrashList");
        }


        public ActionResult TrashList()
        {
            var trashList = mm.WhereTrushMessageList();
            return View(trashList);
        }

        public ActionResult ReadedMessages(int id)
        {
            var YetNotReadedMessages = mm.MessageGetById(id);
            if (YetNotReadedMessages.MessageStatus == true)
            {
                YetNotReadedMessages.MessageStatus = false;
                mm.MessageUpdate(YetNotReadedMessages);
                return View(YetNotReadedMessages);
            }
            else
            {
                return View(YetNotReadedMessages);
            }

        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.MessageDatetime = DateTime.Parse(DateTime.Now.ToShortDateString());
             mm.MessageAdd(message);
            return RedirectToAction("Index");

        }



    }
}