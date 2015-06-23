using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XtremeBlog.DAL;
using XtremeBlog.Model;

namespace XtremeBlog.BLL
{
    public class ComentManager
    {
        ComentDbGateway aComentDbGateway = new ComentDbGateway();
        public void Save(Coment aComent)
        {
            aComentDbGateway.Save(aComent);
        }

        public List<Coment> GetAllComentByPostId(int postId)
        {
            return aComentDbGateway.GetAllComentByPostId(postId);
        }

       
    }
}