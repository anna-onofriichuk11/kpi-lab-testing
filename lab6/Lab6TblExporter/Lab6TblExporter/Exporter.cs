using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Lab6TblExporter
{
    public class Exporter
    {
        public string connectionString = Utils.GetDBConnection();
        public void ExportLicence(string filePath)
        {
            string cmdText = "select WorkType, count(Licensee) as LicenseeNumber from license " +
                   "group by WorkType order by LicenseeNumber";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var cmd = new SqlCommand(cmdText, cn);
                try
                {
                    var fs = new FileStream(filePath, FileMode.OpenOrCreate);
                    SqlDataReader rd = cmd.ExecuteReader();
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        while (rd.Read())
                        {
                            sw.WriteLine($"{rd["WorkType"]};{rd["LicenseeNumber"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void ExportSertificate(string filePath)
        {
            string cmdText = "select ID, OwnerAddress, Certificate, Class from certificationsBusStop " +
                "where Class != 1 order by Class";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var cmd = new SqlCommand(cmdText, cn);
                try
                {
                    var fs = new FileStream(filePath, FileMode.OpenOrCreate);
                    SqlDataReader rd = cmd.ExecuteReader();
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        while (rd.Read())
                        {
                            sw.WriteLine($"{rd["ID"]};{rd["OwnerAddress"]};{rd["Certificate"]};{rd["Class"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
