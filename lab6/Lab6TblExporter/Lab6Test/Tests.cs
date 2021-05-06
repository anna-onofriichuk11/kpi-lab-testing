using NUnit.Framework;

namespace Lab6Test
{
    public class Tests
    {
        string filePathRes1 = "./../../../../../Result1.csv";
        string filePathRes2 = "./../../../../../Result2.csv";
        string filePathExp1 = "./../../../../../Expected1.csv";
        string filePathExp2 = "./../../../../../Expected2.csv";
        string filePathDiff1 = "./../../../../../Difference1.csv";
        string filePathDiff2 = "./../../../../../Difference2.csv";
        string fileLog1 = "./../../../../../log1.txt";
        string fileLog2 = "./../../../../../log2.txt";


        Helper helper = new Helper();

        [Test]
        public void TestLicense()
        {
            bool isDiff = helper.FindDiffInLicense(filePathExp1, filePathRes1, filePathDiff1, fileLog1);

            Assert.IsFalse(isDiff);
        }

        [Test]
        public void TestCertificate()
        {
            bool isDiff = helper.FindDiffInCertificates(filePathExp2, filePathRes2, filePathDiff2, fileLog2);

            Assert.IsFalse(isDiff);
        }
    }
}