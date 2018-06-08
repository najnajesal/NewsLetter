using NewsLetterAPI.DataAccessLayer.BusinessEntities;
using NewsLetterAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NewsLetterAPI.BusinessLayer
{
    public class TechnicalBlogHandler
    {
        public List<TechnicalBlog> LoadAll()
        {
            List<TechnicalBlog> lstBlog = new List<TechnicalBlog>();
            SQLHelper sqlhCDB = new SQLHelper(ConnectionStrings.NewsLetter);
            sqlhCDB.Parameters.Clear();
            DataSet ds = sqlhCDB.ReturnDataSet("[TechnicalBlog_GetData]", CommandType.StoredProcedure);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TechnicalBlog blog = new TechnicalBlog();
                    blog.AttachmentURL = dr["AttachmentURL"].ToString();
                    UserInfo user = new UserInfo();
                    user.EmpID = 1;
                    user.FirstName = "Neenu";
                    user.LastName = "Rama";
                    user.PhoneNumber = "9035721392";
                    blog.Blogger = user;
                    blog.isActive =(bool)dr["isActive"];
                    blog.isPublished = (bool)dr["isPublished"];
                    blog.ShortDescription = dr["ShortDescription"].ToString();
                    blog.LonDescription = dr["LongDescription"].ToString();
                    blog.Topic = dr["Topic"].ToString();
                    blog.CreatedOn =(DateTime) dr["CreatedOn"];
                    lstBlog.Add(blog);
                }
            }
            
            return lstBlog;
        }
    }
}