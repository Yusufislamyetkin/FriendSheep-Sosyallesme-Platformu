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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());

        

        // GET: WriterPanelMessage
        public ActionResult Index()
        {
            string p;
            p = (string)Session["WriterEmail"];


            var MessageList = mm.WhereWriterMessageList(p);


            return View(MessageList);
        }

        public ActionResult NotReadedList()
        {
            string p;
            p = (string)Session["WriterEmail"];

            var NotReadedList = mm.WhereNotReadedWriterMessageList(p);
            return View(NotReadedList);
        }
        public ActionResult ReadedList()
        {
            string p;
            p = (string)Session["WriterEmail"];

            var NotReadedList2 = mm.WhereReadedWriterMessageList(p);
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
            string p;
            p = (string)Session["WriterEmail"];

            var trashList = mm.WhereTrushWriterMessageList(p);
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

        public PartialViewResult MessageViewList()
        {
            string p;
            p = (string)Session["WriterEmail"];

            var MessageList = mm.WhereWriterMessageList(p);
            var NotReadedList = mm.WhereNotReadedWriterMessageList(p);
            var NotReadedList2 = mm.WhereReadedWriterMessageList(p);
            var trashList = mm.WhereTrushWriterMessageList(p);

           
            int messageacount = MessageList.Count();
            int messageNotReadedacount = NotReadedList.Count();
            int messageRedadcount = NotReadedList2.Count();
            int messageTrashcount = trashList.Count();


            ViewBag.AllMessage = messageacount.ToString();
            ViewBag.NotReadedMessages = messageNotReadedacount.ToString();
            ViewBag.ReadedMessages = messageRedadcount.ToString();
            ViewBag.TrashMessages = messageTrashcount.ToString();
            return PartialView();
        }

    }
}