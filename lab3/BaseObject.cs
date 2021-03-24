using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class BaseObject
    {
        public static IWebDriver Driver;
        public static WebDriverBackedSelenium Selenium;

        public static void InitPage<T>(T pageClass) where T : BaseObject
        {
            PageFactory.InitElements(Driver, pageClass);
        }
    }
}
