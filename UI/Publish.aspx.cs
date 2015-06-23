using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XtremeBlog
{
    public partial class Publish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int publishId = int.Parse(Request.QueryString["postId"]);
        }
    }
}