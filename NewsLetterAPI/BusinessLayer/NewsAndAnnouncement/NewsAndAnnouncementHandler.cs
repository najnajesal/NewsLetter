using System;
using System.Collections.Generic;
using NewsLetterAPI.DataAccessLayer.BusinessEntities;
namespace NewsLetterAPI.BusinessLayer
{
    public class NewsAndAnnouncementHandler
    {
        public List<NewsAndAnnouncement> LoadNewsAndAnnouncement()
        {
            List<NewsAndAnnouncement> lstData = new List<NewsAndAnnouncement>();
            try
            {
                for (int i = 0; i <= 10; i++)
                {
                    NewsAndAnnouncement data = new NewsAndAnnouncement();
                    data.ID = i;
                    data.Title = "Title ->" + i;
                    data.Message = "Message ->" + i;
                    data.CreatedBy = "Najna ->" + i;
                    data.Published = false;
                    data.CreatedOn = DateTime.Now;
                    data.PublishDate = DateTime.Now;
                    lstData.Add(data);
                }
            }
            catch (Exception ex)
            {

            }
            return lstData;
        }
    }
}