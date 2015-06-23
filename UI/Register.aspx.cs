using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using XtremeBlog.BLL;
using XtremeBlog.Model;

namespace XtremeBlog
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            User aUser = new User();
            UserManager aUserManager = new UserManager();
            aUser.Name = nameTextBox.Text;
            aUser.Email = emailTextBox.Text;
            aUser.Password = passwordTextBox.Text;
            String msg = aUserManager.SaveUser(aUser);
            msgLabel.Text = msg;
            
           
        }
    }
}