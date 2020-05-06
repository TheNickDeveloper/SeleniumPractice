using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.wikipedia.org/");

                driver.Manage().Window.Maximize();

                var expectedTitle = "wikipedia";
                var actualTitle = driver.Title.ToLower();

                if (expectedTitle != actualTitle)
                {
                    Console.WriteLine("Wrong");
                    return;
                }

                driver.FindElement(By.Id("searchInput")).SendKeys("Southampton");
                driver.FindElement(By.ClassName("pure-button")).Click();

                Console.WriteLine("OK");
            }

            Console.Read();
        }
    }
}
