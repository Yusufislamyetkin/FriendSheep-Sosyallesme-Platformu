using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IHeadingService
    {
        List<Heading> ShowList();
        List<Heading> WhereList(int id);
        List<Heading> WhereListStatus(string sessioninfo);
        List<Heading> WhereListDefStatus(string sessioninfo);
        List<Heading> AdminWhereListDefStatus();
        List<Heading> AdminWhereListStatus();
        List<Heading> WhereListCategory(int id);


        void HeadingAdd(Heading heading);
        void HeadingDelete(Heading heading);
        void HeadingActive(Heading heading);
        void HeadingUpdate(Heading heading);
        Heading GetByID(int id);
    }
}
