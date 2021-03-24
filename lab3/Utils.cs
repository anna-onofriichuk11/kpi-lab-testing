using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Utils : BaseObject
    {   
        public static string baseUrl = "https://thelace.com.ua/";
        private const int DEFAULT_TIMEOUT = 100;

        public static void WaitForElementPresent(string locator, int timeOut = DEFAULT_TIMEOUT)
        {
            for (int i = 0; i < timeOut; i++)
            {

                if (Selenium.IsElementPresent(locator))
                {
                    return;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000); ;
                }
            }
            Assert.Fail("Element '" + locator + "' is not found");
        }
    }
}
