using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {
        List<Content> GetWhereList(int id);
        List<Content> GetWhereWriterList(string session);
        List<Content> GetList();
        List<Content> GetWhereListCat(int id);
        void ContentAdd(Content content);
        void ContentStatus(Content content);
        void ContentUpdate(Content content);
        Content getByID(int id);
      
    }
}
