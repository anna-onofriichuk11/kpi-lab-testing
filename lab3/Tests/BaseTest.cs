using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Tests
{
    class BaseTest : BaseObject
    {
        //public IWebDriver driver;

        [OneTimeSetUp]
        public void beforeClass()
        {
            Driver = new ChromeDriver("C:/Users/Anna/qa-course/lab3/resources");
            //Selenium = new DefaultSelenium()
            //Selenium.Start();
            //Selenium.WindowMaximize();
        }

        [SetUp]
        public void beforeTest()
        {
            Driver.Navigate().GoToUrl(Utils.baseUrl);
        }

        [OneTimeTearDown]
        public void afterClass()
        {
            Driver.Close();
           // Selenium.Close();
        }


    }
}
