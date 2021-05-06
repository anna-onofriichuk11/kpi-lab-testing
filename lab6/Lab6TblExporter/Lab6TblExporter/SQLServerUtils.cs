using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lab6TblExporter
{
    public class SQLServerUtils
    {
        public string GetDBConnection(string dataSource, string initialCatalog, 
            bool inegratedSecurity, bool pooling)
        {
            SqlConnectionStringBuilder connectBuilder = new SqlConnectionStringBuilder();
            connectBuilder.DataSource = dataSource;
            connectBuilder.InitialCatalog = initialCatalog;
            connectBuilder.IntegratedSecurity = inegratedSecurity;
            connectBuilder.Pooling = pooling;
            return connectBuilder.ConnectionString;
        }

        
    }
}
