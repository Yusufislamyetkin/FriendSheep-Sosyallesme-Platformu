using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conctrete
{
   public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

     

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

     
        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message MessageGetById(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> MessageList()
        {
           return _messageDal.List();
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> WhereAdminMessageList()
        {
            return _messageDal.WhrList(x => x.ReceiverMail == "admin@gmail.com" & x.MessageDeletedStatus == false );
        }
        public List<Message> WhereWriterMessageList(string session)
        {
            return _messageDal.WhrList(x => x.ReceiverMail == session & x.MessageDeletedStatus == false);
        }

        public List<Message> WhereCraftMessageList()
        {
            throw new NotImplementedException();
        }

        public List<Message> WhereNotReadedMessageList()
        {
            return _messageDal.WhrList(x => x.MessageStatus == true & x.ReceiverMail == "admin@gmail.com" & x.MessageDeletedStatus==false);
        }
        public List<Message> WhereNotReadedWriterMessageList(string session)
        {
            return _messageDal.WhrList(x => x.MessageStatus == true & x.ReceiverMail == session & x.MessageDeletedStatus == false);
        }

        public List<Message> WhereReadedMessageList()
        {
            return _messageDal.WhrList(x => x.MessageStatus == false & x.ReceiverMail == "admin@gmail.com" & x.MessageDeletedStatus == false);
        }
        public List<Message> WhereReadedWriterMessageList(string session)
        {
            return _messageDal.WhrList(x => x.MessageStatus == false & x.ReceiverMail == session & x.MessageDeletedStatus == false);
        }


        public List<Message> WhereSenderMessageList()
        {
            throw new NotImplementedException();
        }

        public List<Message> WhereTrushMessageList()
        {
            return _messageDal.WhrList(x => x.ReceiverMail == "admin@gmail.com" & x.MessageDeletedStatus == true);
        }
        public List<Message> WhereTrushWriterMessageList(string session)
        {
            return _messageDal.WhrList(x => x.ReceiverMail == session & x.MessageDeletedStatus == true);
        }
    }
}
