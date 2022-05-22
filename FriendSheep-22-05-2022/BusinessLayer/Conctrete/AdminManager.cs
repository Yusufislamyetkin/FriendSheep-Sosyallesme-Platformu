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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public List<Admin> AdminList()
        {
            return _adminDal.List();
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetByAdminId(int id)
        {
            throw new NotImplementedException();
        }

        public Admin GetByAdminLogin(Admin admin)
        {
            return _adminDal.Get(x => x.AdminName == admin.AdminName & x.AdminPassword == admin.AdminPassword);
        }
      

        public Admin GetByAdminUsername(string username)
        {
            return _adminDal.Get(x => x.AdminName == username);
        }

        public List<Admin> WhereAdminList()
        {
            throw new NotImplementedException();
        }
    }
}
