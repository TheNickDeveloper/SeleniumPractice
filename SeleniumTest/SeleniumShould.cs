using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    [TestClass]
    public class SeleniumShould
    {
        [TestMethod]
        public void OpenWebPageAndInterKeyWordThenSearch()
        {
            var executeResult = true;

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.wikipedia.org/");
                driver.Manage().Window.Maximize();

                var expectedTitle = "wikipedia";
                var actualTitle = driver.Title.ToLower();

                if (expectedTitle != actualTitle)
                {
                    Console.WriteLine("Wrong");
                    executeResult = false;
                }

                driver.FindElement(By.Id("searchInput")).SendKeys("Southampton");
                driver.FindElement(By.ClassName("pure-button")).Click();
            }

            Assert.IsTrue(executeResult);
        }

        [TestMethod]
        public void FindAllAnchors()
        {
            var anchorsNameList = new List<string>();

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.wikipedia.org/");

                var anchorsList = driver.FindElements(By.TagName("a"));

                foreach (var anchor in anchorsList)
                {
                    if (anchor.Displayed)
                    {
                        anchorsNameList.Add(anchor.Text);
                    }
                }
            }

            Assert.IsTrue(anchorsNameList.Count > 0);
        }

        [TestMethod]
        public void SelectLanguageFromDropDownBox()
        {
            var allLanguages = new List<string>();

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.wikipedia.org/");

                var searchLanguages = new SelectElement(driver.FindElement(By.Id("searchLanguage")));

                // get all options from dropdown
                var languageOptions = searchLanguages.Options;
                languageOptions.ToList().ForEach(lan => allLanguages.Add(lan.Text));

                //select language from dropdown box
                searchLanguages.SelectByValue("ja");
            }

            Assert.IsTrue(allLanguages.Count > 0);
        }

        [TestMethod]
        public void LoginFacebook()
        {
            var executeResult = true;
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    driver.Navigate().GoToUrl("https://www.facebook.com/");

                    driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("nick921209@gmail.com");
                    driver.FindElement(By.XPath("//*[@id='pass']")).SendKeys("");
                    driver.FindElement(By.XPath("//*[@id='loginbutton']")).Click();
                    driver.FindElement(By.ClassName("_1frb")).SendKeys("Stanly");
                }
            }
            catch (Exception e)
            {
                executeResult = false;
            }

            Assert.IsTrue(executeResult);
        }

        [TestMethod]
        public void RegistFacebookAccount()
        {
            var executeResult = true;
            try
            {
                using (IWebDriver driver = new ChromeDriver())
                {
                    driver.Navigate().GoToUrl("https://www.facebook.com/");

                   
                    driver.FindElement(By.XPath("//*[@id='u_0_7']")).Click();

                    var year = new SelectElement(driver.FindElement(By.Id("year")));
                    var month = new SelectElement(driver.FindElement(By.Id("month")));
                    var day = new SelectElement(driver.FindElement(By.Id("day")));

                    year.SelectByValue("1991");
                    month.SelectByValue("2");
                    day.SelectByValue("26");

                    driver.FindElement(By.XPath("//*[@id='u_0_m']")).SendKeys("Tsai");
                    driver.FindElement(By.XPath("//*[@id='u_0_o']")).SendKeys("Nick");
                }
            }
            catch (Exception e)
            {
                executeResult = false;
            }

            Assert.IsTrue(executeResult);
        }
    }
}
