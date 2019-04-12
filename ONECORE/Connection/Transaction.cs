using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OneCore.Connection
{
    public class Transaction
    {
        public IDbConnection Connection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-55FLLNI\SQLEXPRESS;Initial Catalog=banco_one;Integrated Security=SSPI");
        }
        
    }
}