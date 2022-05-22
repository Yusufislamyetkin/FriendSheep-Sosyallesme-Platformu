using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string Categoryimages { get; set; }

        public bool CategoryStatus { get; set; }

        public ICollection<Heading> Headings { get; set; } // Birden Fazla Başlıkta Yer Alabilirim. Onaylandı
    }
}
