using lab3.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3
{
    class LoginPage : BaseObject
    {

        private const string LOGIN_PAGE_LINK = "//*[@id=\"masthead\"]/div[1]/div/div[3]/div[1]/a";
        private const string EMAIL_FIELD = "username";
        private const string PASSWORD_FIELD_ID = "panel_password";
        private const string LOGIN_BUTTON = "login";
        private const string MODAL_WINDOW = "//*[@id=\"login-panel\"]/div[2]/div[3]/form[1]/div/ul/li";


        [FindsBy(How = How.XPath, Using = LOGIN_PAGE_LINK)]
        public IWebElement loginLink;

        [FindsBy(How = How.Name, Using = EMAIL_FIELD)]
        public IWebElement emailField;

        [FindsBy(How = How.Id, Using = PASSWORD_FIELD_ID)]
        public IWebElement passwordField;

        [FindsBy(How = How.Name, Using = LOGIN_BUTTON)]
        public IWebElement loginBtn;

        public static LoginPage GetLoginPage()
        {
            LoginPage loginPage = new LoginPage();
            InitPage(loginPage);
            return loginPage;
        }

        public LoginPage GoToLoginPage()
        {
            loginLink.Click();
            Thread.Sleep(1000);
            return GetLoginPage();

        }

        public LoginPage PrintEmail(string email)
        {
            emailField.SendKeys(email);
            return GetLoginPage();
        }

        public LoginPage PrintPassword(string password)
        {
            passwordField.SendKeys(password);
            return GetLoginPage();
        }

        public StartPage ClickLoginBtn()
        {
            loginBtn.Click();
            return StartPage.GetStartPage();
        }

        public LoginPage AssertIncorrectModal()
        {
            Thread.Sleep(9000);
            Driver.FindElement(By.XPath(MODAL_WINDOW));
            return this;
        }


    }
}
