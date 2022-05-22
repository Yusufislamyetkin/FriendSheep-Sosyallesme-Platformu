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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public Writer GetBySession(string session)
        {
            return _writerDal.Get(x => x.WriterEmail == session);
        }
    
        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WAdd(Writer w)
        {
             _writerDal.Insert(w);
        }

        public void WDelete(Writer w)
        {
            _writerDal.Delete(w);
        }

        public void WUpdate(Writer w)
        {
            _writerDal.Update(w);
        }
    }
}
