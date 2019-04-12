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
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HOST;Integrated Security=SSPI");
        }
        
    }
}