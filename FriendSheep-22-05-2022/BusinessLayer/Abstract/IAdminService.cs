using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        Admin GetByAdminId(int id);
        Admin GetByAdminLogin(Admin admin);
        Admin GetByAdminUsername(string username);
        List<Admin> AdminList();
        List<Admin> WhereAdminList();
        void AdminAdd(Admin admin);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
