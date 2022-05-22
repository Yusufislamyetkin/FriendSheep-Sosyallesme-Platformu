using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        Writer GetByID(int id);
        Writer GetBySession(string session);
        List<Writer> GetList();
        void WAdd(Writer w);
        void WDelete(Writer w);
        void WUpdate(Writer w);

    }
}
