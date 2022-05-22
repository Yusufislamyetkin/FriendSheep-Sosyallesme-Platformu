using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> MessageList();

        List<Message> WhereTrushMessageList();
        List<Message> WhereAdminMessageList();
        List<Message> WhereReadedMessageList();
        List<Message> WhereNotReadedMessageList();


        List<Message> WhereWriterMessageList(string session);
        List<Message> WhereNotReadedWriterMessageList(string session);
        List<Message> WhereReadedWriterMessageList(string session);
        List<Message> WhereTrushWriterMessageList(string session);


        List<Message> WhereCraftMessageList();
        List<Message> WhereSenderMessageList();

        Message MessageGetById(int id);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);



    }
}
