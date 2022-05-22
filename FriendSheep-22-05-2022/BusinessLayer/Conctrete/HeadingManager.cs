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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

    
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public void HeadingActive(Heading heading)
        {
            heading.HeadingStatus = true;
            _headingDal.Update(heading);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            heading.HeadingStatus = false;
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> ShowList()
        {
            return _headingDal.List();
        }

        public List<Heading> WhereList(int id)
        {
            return _headingDal.WhrList(x => x.WriterID == id);
        }

        public List<Heading> WhereListCategory(int id)
        {
            return _headingDal.WhrList(x => x.CategoryID ==id);
        }


        public List<Heading> WhereListDefStatus(string sessioninfo)
        {
            return _headingDal.WhrList(x => x.HeadingStatus == false & x.Writer.WriterEmail == sessioninfo);
        }
       
        public List<Heading> WhereListStatus(string sessioninfo)
        {


            return _headingDal.WhrList(x => x.HeadingStatus == true & x.Writer.WriterEmail == sessioninfo);
        }
        public List<Heading> AdminWhereListDefStatus()
        {
            return _headingDal.WhrList(x => x.HeadingStatus == false);
        }
        public List<Heading> AdminWhereListStatus()
        {


            return _headingDal.WhrList(x => x.HeadingStatus == true);
        }
    }
}
