using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3.Pages
{
    public class SearchPage : BaseObject
    {

        private const string SEARCH_PAGE_LINK = "//*[@id=\"masthead\"]/div[1]/div/div[3]/div[2]";
        private const string SEARCH_FIELD_NAME = "s";
        private const string QUICK_LINKS= "#masthead > div.header-main.header-contents.has-center.menu-center > div > div.header-right-items.header-items > div.header-search.icon > div";
        private const string PRODUCT_RESULT_LIST = "//*[@id=\"main\"]/ul/li[2]";
        private const string SEARCH_IS_NOT_SUCCESFULL_MSG_CLASS = "woocommerce-info";

        [FindsBy(How = How.XPath, Using = SEARCH_PAGE_LINK)]
        public IWebElement searchPageLink;

        [FindsBy(How = How.Name, Using = SEARCH_FIELD_NAME)]
        public IWebElement searchField;


        public static SearchPage GetSearchPage()
        {
            SearchPage searchPage = new SearchPage();
            InitPage(searchPage);
            return searchPage;
        }

        public SearchPage GoToSearchPage()
        {
            searchPageLink.Click();
            return GetSearchPage();  
        }

        public SearchPage PrintSerchRequest(string searchRequest)
        {
            searchField.SendKeys(searchRequest);
            return GetSearchPage();
        }

        public SearchPage AssertTips()
        {
            Thread.Sleep(2000);
            Driver.FindElement(By.CssSelector(QUICK_LINKS));
            return GetSearchPage();
        }

        public SearchPage AssetsSearchList()
        {
            
            Driver.FindElement(By.XPath(PRODUCT_RESULT_LIST));
            return GetSearchPage();
        }

        public SearchPage AssetsUnseccesfullSearchMsg()
        {
            Driver.FindElement(By.ClassName(SEARCH_IS_NOT_SUCCESFULL_MSG_CLASS));
            return GetSearchPage();
        }
    }
}
