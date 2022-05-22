using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T>
    {
        //Crud oparesyon method tanımlamaları yapılacak

        List<T> List();
        void Insert(T p);
        void Delete(T p);
        void Update(T p);
        T Get(Expression<Func<T, bool>> filter);
        List<T> WhrList(Expression<Func<T, bool>> filter);
    }
}
