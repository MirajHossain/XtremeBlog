using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XtremeBlog.BLL;
using XtremeBlog.Model;

namespace XtremeBlog
{
    public partial class Home : System.Web.UI.Page
    {
      
       
        protected void Page_Load(object sender, EventArgs e)
        {

            UserPostViewManager aUserPostViewManager = new UserPostViewManager();
            List<UserPostView> userPost = aUserPostViewManager.FindAllUserPost();
      
        }

   }
}