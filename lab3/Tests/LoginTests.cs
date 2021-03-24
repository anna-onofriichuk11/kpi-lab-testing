using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Tests
{
    [TestFixture]
    class LoginTests : BaseTest
    {
        private static LoginHelper loginHelper = new LoginHelper();

        [Test]
        public static void CorrectLoginTest()
        {
            string email = "anna.onofriichuk2001@gmail.com";
            string password = "anna22062001";

            string expectedUserName = "Мой аккаунт";

            loginHelper
                .Login(email, password)
                .AssertUserName(expectedUserName);
        }


        [Test]
        public static void InCorrectLoginTest()
        {
            string email = "anna.onofriichuk2001@gmail.com";
            string password = "12345678";

            loginHelper
                .Login(email, password)
                .AssertIncorrectData();
        }
    }
}
