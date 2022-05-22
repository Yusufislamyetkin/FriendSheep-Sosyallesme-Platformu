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
    public class GalleryManager : IGalleryService
    {
        IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public Gallery GalleryGetByid(int id)
        {
            return _galleryDal.Get(x => x.GalleryID == id);
        }

        public List<Gallery> GalleryList()
        {
            return _galleryDal.List();
        }

        public void GallerytAdd(Gallery gallery)
        {
            _galleryDal.Insert(gallery);
        }

        public void GallerytDelete(Gallery gallery)
        {
            _galleryDal.Delete(gallery);
        }

        public void GalleryUpdate(Gallery gallery)
        {
            _galleryDal.Update(gallery);
        }

        public List<Gallery> WhereGalleryList(Gallery gallery)
        {
            throw new NotImplementedException();
        }
    }
}
