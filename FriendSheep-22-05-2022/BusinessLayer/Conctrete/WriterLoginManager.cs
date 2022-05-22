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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterLoginDal _WriterLoginDal;

        public WriterLoginManager(IWriterLoginDal writerLoginDal)
        {
            _WriterLoginDal = writerLoginDal;
        }

        public Writer GetByWriterId(int id)
        {
          return   _WriterLoginDal.Get(x => x.WriterID == id);
        }

        public Writer GetByWriterLogin(Writer writer)
        {
            return _WriterLoginDal.Get(x => x.WriterEmail == writer.WriterEmail & x.WriterPassword == writer.WriterPassword);
        }

        public Writer GetByWriterUsername(string username)
        {
            return _WriterLoginDal.Get(x => x.WriterEmail == username);
        }

        public List<Writer> WhereWriterList()
        {
            throw new NotImplementedException();
        }

        public void WriterAdd(Writer writer)
        {
            throw new NotImplementedException();
        }

        public void WriterDelete(Writer writer)
        {
            throw new NotImplementedException();
        }

        public List<Writer> WriterList()
        {
            throw new NotImplementedException();
        }

        public void WriterUpdate(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
