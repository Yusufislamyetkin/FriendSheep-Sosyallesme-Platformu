using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContactService
    {
        List<Contact> ContactList();
        Contact ContactGetByid(int id);
        List<Contact> WhereContactList(Contact contact);
       
        void ContactAdd(Contact contact);
        void ContactDelete(Contact Contact);
        void ContactUpdate(Contact Contact);
    }
}
