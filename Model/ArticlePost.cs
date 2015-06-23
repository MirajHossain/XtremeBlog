using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XtremeBlog.Model
{
    public class ArticlePost
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string DateTime { get; set; }
        public string Content { get; set; }
        public int ViewCounter { get; set; }
        public int UserId { get; set; }
        public string PostStatus { get; set; }

    }
}