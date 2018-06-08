
using System;
using static NewsLetterAPI.Constant;

namespace NewsLetterAPI.DataAccessLayer.BusinessEntities
{
    public class EmployeeFeeds
    {
        public EmployeeFeedTypes Type { get; set; }
        public UserInfo EmployeeDetails { get; set; }
        public DateTime Date { get; set; }
        
    }
}