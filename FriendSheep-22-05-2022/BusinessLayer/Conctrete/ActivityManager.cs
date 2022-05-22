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
    public class ActivityManager : IActivityService
    {
        IActivityDal _activityDal;

        public ActivityManager(IActivityDal activityDal)
        {
            _activityDal = activityDal;
        }

        public void Add(Activity activity)
        {
            _activityDal.Insert(activity);
        }

        public void Delete(Activity activity)
        {
            _activityDal.Delete(activity);
        }

        public Activity GetByid(int id)
        {
          return  _activityDal.Get(x => x.activityID == id);
        }

        public List<Activity> List()
        {
            return _activityDal.List();
        }

        public void Update(Activity activity)
        {
            _activityDal.Update(activity);
        }

        public List<Activity> WhereList()
        {
          return  _activityDal.WhrList(x => x.activityCity == "İstanbul");
        }


        public List<Activity> WhereListCity2()
        {
            return _activityDal.WhrList(x => x.activityCity == "Ankara");
        }

        

        public List<Activity> WhereListCity3()
        {
            return _activityDal.WhrList(x => x.activityCity == "İzmir");
        }


        

        public List<Activity> WhereListCity4()
        {
            return _activityDal.WhrList(x => x.activityCity == "Eskişehir");
        }


        
    }
}
