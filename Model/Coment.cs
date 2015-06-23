using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XtremeBlog.Model
{
    public class Coment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public int PostId { get; set; }
        public int UseId { get; set; }
      
    }
}