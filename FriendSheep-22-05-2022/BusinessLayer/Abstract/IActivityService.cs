using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public interface IActivityService
    {
        List<Activity> List();
        Activity GetByid(int id);
        List<Activity> WhereList();

        void Add(Activity activity);
        void Delete(Activity activity);
        void Update(Activity activity);
    }
}
