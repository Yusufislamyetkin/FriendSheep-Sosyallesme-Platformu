using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IWriterLoginService
    {
        Writer GetByWriterId(int id);
        Writer GetByWriterLogin(Writer writer);
        Writer GetByWriterUsername(string username);
        List<Writer> WriterList();
        List<Writer> WhereWriterList();
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);

    }
}
