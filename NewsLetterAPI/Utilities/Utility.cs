using NewsLetterAPI.Utilities;
using System.Configuration;

namespace NewsLetterAPI
{
    public class Constant
    {
        //Newly hired Employee,Birthdays,Anniversay
        public enum EmployeeFeedTypes { NewEmp = 1, BdyEmp = 2,AnnvEmp=3 }

    }
    public class Utility
    {
        public static ConnectionStringSettings GetConnectionString(Utilities.ConnectionStrings e = ConnectionStrings.NewsLetter)
        {
            string TestMode = ConfigurationManager.AppSettings["TestingServer"];
            ConnectionStringSettings conn = null;
            if (e == ConnectionStrings.NewsLetter)
            {
                switch (TestMode)
                {
                    case "1":
                        conn = ConfigurationManager.ConnectionStrings["NewsLetterApp"];
                        break;
                    
                }
            }
            else
            {
                switch (TestMode)
                {
                    case "1":
                        conn = ConfigurationManager.ConnectionStrings["NewsLetterApp"];
                        break;
                }
            }
            if (conn != null)
                return conn;
            else
                return ConfigurationManager.ConnectionStrings["NewsLetterApp"];
        }
    }
}