using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lab6TblExporter
{
    public class Utils
    {
        public static string GetDBConnection()
        {
            SQLServerUtils serverUtils = new SQLServerUtils();
            string DataSource = @"DESKTOP-0F8GKFP\SQLEXPRESS";

            string InitialCatalog = "Transport";

            bool IntegretedSecurity = true;

            bool Pooling = true;
            return serverUtils.GetDBConnection(DataSource, InitialCatalog, IntegretedSecurity, Pooling);
        }
    }
}
