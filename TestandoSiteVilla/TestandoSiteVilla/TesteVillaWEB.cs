using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestandoSiteVilla
{
    [TestFixture]
    class TesteVillaWEB
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void AbrirNavegador()
        {
            driver = new ChromeDriver("C:\\Users\\Admin\\Downloads\\chromedriver_win32");
            driver.Manage().Window.Maximize();
            baseURL="https://www.escolavillaencantada.com.br";
        }

        [Test(Description = "Teste de Login")]
        public void AcessarAreaDaFamilia()
        {
            driver.Navigate().GoToUrl(baseURL);
            IWebElement AccessButton = driver.FindElements(By.CssSelector("div#navbarNormalText span.navbar-text a[href='./areadafamilia'] button"))[0];

            Thread.Sleep(3000);

            AccessButton.Click();

            IWebElement emailinput = driver.FindElement(By.Id("pmatricula"));
            IWebElement passinput = driver.FindElement(By.Id("pSenhaNet"));

            Thread.Sleep(3000);

            emailinput.SendKeys("mail@mail.com.br");
            passinput.SendKeys("123456");

            Thread.Sleep(3000);

            IWebElement submitButton = driver.FindElement(By.CssSelector("form#form_login button[type='submit']"));
            submitButton.Click();

            Thread.Sleep(3000);

            IWebElement errorValidation = driver.FindElement(By.CssSelector("div#errorsMesages div[role='alert'] strong"));

            Assert.AreEqual(errorValidation.Text, "Email Existe no Sistema!");



        }

        [TearDown]
        public void TeardownTest()
        {
            // driver.Close(); 
        }
       
    }
}
