using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsLetterAPI.DataAccessLayer.BusinessEntities
{
    public class NewsAndAnnouncement
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public bool Published { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}