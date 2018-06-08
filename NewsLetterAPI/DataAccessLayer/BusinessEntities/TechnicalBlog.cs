using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NewsLetterAPI.DataAccessLayer.BusinessEntities
{
    public class TechnicalBlog
    {
        public int ID { get; set; }
        public string Topic { get; set; }
        public string ShortDescription { get; set; }
        public string LonDescription { get; set; }
        public  string AttachmentURL { get; set; }
        public UserInfo Blogger { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool isActive { get; set; }
        public bool isPublished { get; set; }
    }
}