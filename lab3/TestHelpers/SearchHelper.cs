using lab3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3.TestHelpers
{
    class SearchHelper
    {

        private SearchPage searchPage = new SearchPage();

        public SearchHelper Search(string searchRequest)
        {
            BaseObject.InitPage(searchPage);
            searchPage.
                GoToSearchPage().
                PrintSerchRequest(searchRequest).searchPageLink.Click();
            return this;
        }

        public bool AssertTipsIsPresent()
        {
            searchPage.AssertTips();
            return false;
        }
        public SearchHelper AssertProductListIsShown()
        {
            Thread.Sleep(4000);
            searchPage.AssetsSearchList();
            return this;
        }

        public SearchHelper AssertMeesage()
        {
            Thread.Sleep(1000);
            searchPage.AssetsUnseccesfullSearchMsg();
            return this;
        }


    }
}
