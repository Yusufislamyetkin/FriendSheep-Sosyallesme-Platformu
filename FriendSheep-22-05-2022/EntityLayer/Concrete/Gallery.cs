using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Gallery
    {
        [Key]
        public int GalleryID { get; set; }
        [StringLength(150)]
        public string PicturePath { get; set; }
        [StringLength(30)]
        public string PictureName { get; set; }
    }
}
