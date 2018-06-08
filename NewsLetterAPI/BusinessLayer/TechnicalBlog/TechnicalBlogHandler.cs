using NewsLetterAPI.DataAccessLayer.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsLetterAPI.BusinessLayer
{
    public class TechnicalBlogHandler
    {
        public List<TechnicalBlog> LoadAll()
        {
            List<TechnicalBlog> lstBlog = new List<TechnicalBlog>();
            TechnicalBlog blog = new TechnicalBlog();
            blog.AttachmentURL = string.Empty;
            UserInfo user = new UserInfo();
            user.EmpID = 1;
            user.FirstName = "Neenu";
            user.LastName = "Rama";
            user.PhoneNumber = "9035721392";
            blog.Blogger = user;
            blog.isActive = true;
            blog.isPublished = true;
            blog.LonDescription = "";
            lstBlog.Add(blog);
            return lstBlog;
        }
    }
}