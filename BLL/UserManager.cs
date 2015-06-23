using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XtremeBlog.DAL;
using XtremeBlog.Model;

namespace XtremeBlog.BLL
{
    public class UserManager
    {
        UserDbGateway aUserDbGateway = new UserDbGateway();
        public string SaveUser(User aUser)
        {
           
            int insert= aUserDbGateway.SaveUser(aUser);
            if (insert > 0)
            {
                return "You have registered in XtremeBlog";
            }
            else
            {
                return "error";
            }
        }

        public List<User> GetAllUser()
        {
           return aUserDbGateway.GetAllUser();
        }


        public User GetAllUserById(int useId)
        {
           return aUserDbGateway.GetAllUserById(useId);
        }
    }
}