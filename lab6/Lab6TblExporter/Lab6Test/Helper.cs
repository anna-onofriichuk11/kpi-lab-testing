using CsvHelper;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab6Test
{
    public class Helper
    {
        public bool FindDiffInLicense(string expecFilePath, string actualFilePath, string diffFilePath, string fileLogPath)
        {

            List<LicenseModel> expecLst = getLicenseModels(expecFilePath);
            List<LicenseModel> actualLst = getLicenseModels(actualFilePath);

            return getDifferenceLicense(expecLst, actualLst, diffFilePath, fileLogPath);
        }

        private bool getDifferenceLicense(List<LicenseModel> expecLst, List<LicenseModel> actualLst, string filePath, string fileLogPath)
        {
            bool isDiff = false;
            int coincidenceNum = 0;
            int differencesNum = 0;
            int length = expecLst.Count > actualLst.Count ? actualLst.Count : expecLst.Count;
            for(int i=0; i<length; i++)
            {
                if (expecLst[i].WorkType == actualLst[i].WorkType
                    && expecLst[i].LicenseeNumber == actualLst[i].LicenseeNumber)
                {
                    coincidenceNum++;
                    continue;
                }

                differencesNum++;
                isDiff = true;
                string str = "";

                if (expecLst[i].WorkType != actualLst[i].WorkType)
                    str += $"{expecLst[i].WorkType};{actualLst[i].WorkType}";
                else
                    str += ";;";
                
                if(expecLst[i].LicenseeNumber != actualLst[i].LicenseeNumber)
                    str += $";;{expecLst[i].LicenseeNumber};{actualLst[i].LicenseeNumber}";
                else
                    str += ";;";

                var fs = new FileStream(filePath, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(str);
                }

            }
            createLog("License tables", fileLogPath, coincidenceNum, differencesNum);
            return isDiff;
        }

        private void createLog(string message, string fileLogPath, int coincidenceNum, int differencesNum)
        {
            var fs = new FileStream(fileLogPath, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(message);
                sw.WriteLine($"Identical records number: {coincidenceNum}");
                sw.WriteLine($"Different records number: {differencesNum}");
            }

        }

        private List<LicenseModel> getLicenseModels(string filePath)
        {
            List<LicenseModel> modelsLst = new List<LicenseModel>();
            string[] lines = { "\r\n" };
            using (StreamReader sr = new StreamReader(filePath))
            {
                lines = sr.ReadToEnd().Split(lines, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    string[] strs = line.Split(";");

                    modelsLst.Add(new LicenseModel
                    {
                        WorkType = strs[0],
                        LicenseeNumber = strs[1]
                    });
                }

            }

            return modelsLst;
        }

        public bool FindDiffInCertificates(string expecFilePath, string actualFilePath, string diffFilePath, string fileLogPath)
        {

            List<CertificteModel> expecLst = getCertificateModels(expecFilePath);
            List<CertificteModel> actualLst = getCertificateModels(actualFilePath);

            return getDifferenceCertificates(expecLst, actualLst, diffFilePath, fileLogPath);
        }

        private List<CertificteModel> getCertificateModels(string filePath)
        {
            List<CertificteModel> modelsLst = new List<CertificteModel>();
            string[] lines = { "\r\n" };
            using (StreamReader sr = new StreamReader(filePath))
            {
                lines = sr.ReadToEnd().Split(lines, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    string[] strs = line.Split(";");

                    modelsLst.Add(new CertificteModel
                    {
                        ID = strs[0],
                        OwnerAddress = strs[1],
                        Certificate = strs[2],
                        Class = strs[3]
                    });
                }

            }

            return modelsLst;
        }

        private bool getDifferenceCertificates(List<CertificteModel> expecLst, List<CertificteModel> actualLst, string filePath, string fileLogPath)
        {
            bool isDiff = false;
            int coincidenceNum = 0;
            int differencesNum = 0;
            int length = expecLst.Count > actualLst.Count ? actualLst.Count : expecLst.Count;
            createHeaderCertificate(filePath);
            for (int i = 0; i < length; i++)
            {
                if (isIdentical(expecLst[i], actualLst[i]))
                {
                    coincidenceNum++;
                    continue;
                }

                differencesNum++;
                isDiff = true;
                string str = "";

                if (expecLst[i].ID != actualLst[i].ID)
                    str += $"{expecLst[i].ID};{actualLst[i].ID}";
                else
                    str += ";;";

                if (expecLst[i].OwnerAddress != actualLst[i].OwnerAddress)
                    str += $"{expecLst[i].OwnerAddress};{actualLst[i].OwnerAddress}";
                else
                    str += ";;";

                if (expecLst[i].Certificate != actualLst[i].Certificate)
                    str += $"{expecLst[i].Certificate};{actualLst[i].Certificate}";
                else
                    str += ";;";

                if (expecLst[i].Class != actualLst[i].Class)
                    str += $"{expecLst[i].Class};{actualLst[i].Class}";
                else
                    str += ";;";



                var fs = new FileStream(filePath, FileMode.Append);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(str);
                }

            }
            createLog("Certificate tables", fileLogPath, coincidenceNum, differencesNum);
            return isDiff;
        }

        private void createHeaderCertificate(string filePath)
        {
            var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine("ID-expected;ID-actual;Owner address-expected;Owner address-actual;" +
                     "Class-expected;Class-actual;Certificate-expected;Certificate-actual");
            }

        }

        private bool isIdentical(CertificteModel expected, CertificteModel actual)
        {
            if (expected.ID != actual.ID
              /*  || expected.Owner != actual.Owner
                || expected.OwnerAddress != actual.OwnerAddress
                || expected.Station != actual.Station*/
                || expected.OwnerAddress != actual.OwnerAddress
        /*        || expected.Term != actual.Term*/
                || expected.Class != actual.Class
                || expected.Certificate != actual.Certificate)
                return false;
            return true;
        }
    }
}
