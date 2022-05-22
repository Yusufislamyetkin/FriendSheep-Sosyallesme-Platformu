using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Activity
    {
        public int activityID { get; set; }
        public String activityContent { get; set; }
        public String activityHeading { get; set; }
        public String activityImage { get; set; }
        public DateTime activityDateTime { get; set; }
        public String activityCity { get; set; }
        public bool activityControl { get; set; }
  
        public int activityPrice { get; set; }


        public int WriterID { get; set; } // Onaylandı
        public virtual Writer Writer { get; set; }
    }
}
