using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syndicate.Classes
{
    public class LoginCheck
    {
        public string[] Authenticate()
        {
            string[] auth = new string[2];

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_getAdminLogin").ToArray();
                String Name = data[0].Name.ToString();
                String password = data[0].password.ToString();
                
                auth[0] = Name;
                auth[1] = password;
            }
            return auth;
        }

    }
}