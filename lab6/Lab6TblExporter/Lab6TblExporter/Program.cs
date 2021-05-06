using System;
using System.Data.SqlClient;
using System.IO;

namespace Lab6TblExporter
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Utils utils = new Utils();
            Console.WriteLine("Getting Connection ...");
            string conn = utils.GetDBConnection();*/

            string filePathRes1 = "./../../../../../Result1.csv";
            string filePathRes2 = "./../../../../../Result2.csv";
            Exporter exporter = new Exporter();

            try
            {
                exporter.ExportLicence(filePathRes1);
                exporter.ExportSertificate(filePathRes2);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}
