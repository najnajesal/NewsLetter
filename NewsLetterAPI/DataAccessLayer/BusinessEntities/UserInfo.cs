using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsLetterAPI.DataAccessLayer.BusinessEntities
{
    public class UserInfo
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }
        public int OrgID { get; set; }
        public string Toekn { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileURL { get; set; }
    }
}