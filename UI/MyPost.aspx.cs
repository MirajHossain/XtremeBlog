using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XtremeBlog.BLL;

namespace XtremeBlog
{
    public partial class MyPost : System.Web.UI.Page
    {
        PostManager aPostManager = new PostManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null || Session["Email"] != null)
            {
               int userId = Convert.ToInt32(Session["UserId"]);
               
              
            }

        }
    }
}