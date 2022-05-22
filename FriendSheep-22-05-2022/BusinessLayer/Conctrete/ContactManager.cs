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
    public class ContactManager : IContactService
    {
        IContactDal _ContactDal;

        public ContactManager(IContactDal contactDal)
        {
            _ContactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _ContactDal.Insert(contact);
        }

        public void ContactDelete(Contact Contact)
        {
            _ContactDal.Delete(Contact);
        }

        public Contact ContactGetByid(int id)
        {
           
            return _ContactDal.Get(x => x.ContactID  == id);
        }

        public List<Contact> ContactList()
        {
            return _ContactDal.List();
        }

        public void ContactUpdate(Contact Contact)
        {
            _ContactDal.Update(Contact);
        }

        public List<Contact> WhereContactList(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
