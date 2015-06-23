using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XtremeBlog.BLL;
using XtremeBlog.Model;

namespace XtremeBlog
{
    public partial class Login : System.Web.UI.Page
    {
       
        UserManager aUserManager = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            List<User> users = aUserManager.GetAllUser();
            foreach (User user in users)
            {
                if (user.Name == nameTextBox.Text || user.Email == nameTextBox.Text)
                    
                {
                    if (user.Password == passwordTextBox.Text)
                    {
                        Session["username"] = user.Name;
                        Session["Email"] = user.Password;
                        Session["UserId"] = user.UserId;
                        Response.Redirect("Home.aspx?userId= "+user.UserId+"");
                    }
                    else
                    {
                        accountLabel.Text = "Create an Account";
                        msgLabel.Text = "Please User name or Password Spelled correctly!";
                       
                    }
                }
               
                
            }
            
        }
    }
}