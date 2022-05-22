using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IGalleryService
    {
        List<Gallery> GalleryList();
        Gallery GalleryGetByid(int id);
        List<Gallery> WhereGalleryList(Gallery gallery);

        void GallerytAdd(Gallery gallery);
        void GallerytDelete(Gallery gallery);
        void GalleryUpdate(Gallery gallery);
    }
}
