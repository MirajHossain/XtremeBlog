using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XtremeBlog.DAL;
using XtremeBlog.Model;

namespace XtremeBlog.BLL
{
    public class UserPostViewManager
    {
        PostDbGateway aPostDbGateway = new PostDbGateway();
        UserPostViewBbGateway aUserPostViewBbGateway =new UserPostViewBbGateway();
        public List<UserPostView> FindAllUserPost()
        {
            return aUserPostViewBbGateway.FindAllUerPost();
        }

        public List<UserPostView> FindUserPostById(int userId)
        {
            return aUserPostViewBbGateway.FindUerPostById(userId);
        }

        public void UpdatePost(int publishId)
        {
            aPostDbGateway.UpdatePost(publishId);
        }
    }
}