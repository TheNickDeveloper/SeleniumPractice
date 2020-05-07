using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice
{
    public class LoginInfoPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='u_0_7']")]
        public IWebElement RadioBtnGenderMale { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='u_0_o']")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='u_0_m']")]
        public IWebElement FistName { get; set; }

        [FindsBy(How = How.Id, Using = "year")]
        public SelectElement BirthYear { get; set; }

        [FindsBy(How = How.Id, Using = "month")]
        public SelectElement BirthMonth { get; set; }

        [FindsBy(How = How.Id, Using = "day")]
        public SelectElement BirthDay { get; set; }

        public void SelectGenderAsMale()
        {
            RadioBtnGenderMale.Click();
        }
    }
}
