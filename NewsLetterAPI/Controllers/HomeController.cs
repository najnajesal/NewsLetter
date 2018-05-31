using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsLetterAPI.DataAccessLayer.BusinessEntities;
using NewsLetterAPI.BusinessLayer;

namespace NewsLetterAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public List<NewsAndAnnouncement> GetNewsAndAnnouncements()
        {
            List<NewsAndAnnouncement> lstData = new List<NewsAndAnnouncement>();
            try
            {
                NewsAndAnnouncementHandler handler = new NewsAndAnnouncementHandler();
                lstData = handler.LoadNewsAndAnnouncement();
            }
            catch (Exception ex)
            {
               //catch
            }
            return lstData;
        }
    }
    
}
