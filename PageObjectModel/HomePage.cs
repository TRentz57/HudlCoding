using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HudlCoding.PageObjectModel
{
    public class HomePage
    {
        public IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement homeBtn => driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/nav[1]/div[2]/a[1]/span"));
    }
}
