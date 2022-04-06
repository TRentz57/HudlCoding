using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HudlCoding.PageObjectModel
{
    public class LoginPage
    {
        public IWebDriver driver;
        public string email = "Trentz2016@gmail.com";
        public string password = "538Plate";
        public string badEmail = "Hello@test.com";
        public string badPwd = "ansfaief";
        public string sqlInj = "SELECT * FROM Emails";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement EmailField => driver.FindElement(By.Id("email"));
        public IWebElement PasswordField => driver.FindElement(By.Id("password"));
        public IWebElement loginBtn => driver.FindElement(By.XPath("/ html / body / div[2] / form[1] / div[4] / div / button"));
        public IWebElement loginFailTxt => driver.FindElement(By.XPath("/ html / body / div[2] / form[1] / div[3] / div / p "));
        
        
        public void ClickLoginButtonFail()
        {

            loginBtn.Click();
            Thread.Sleep(2000);
            string test = loginFailTxt.Text;
            Console.WriteLine(test);

            if (test == "We didn't recognize that email and/or password. Need help?")
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        public void EnterEmail()
        {

            EmailField.SendKeys(email);
           
        }
        public void EnterPassword()
        {

            PasswordField.SendKeys(password);
         
        }
        public void EnterWrongPassword()
        {

            PasswordField.SendKeys(badPwd);
      
        }
        public void EnterWrongEmail()
        {

            EmailField.SendKeys(badEmail);
         
        }
        public void EnterSQlInjEmail()
        {
            EmailField.SendKeys(sqlInj);
        }
        public void EnterSQlInjPwd()
        {
            PasswordField.SendKeys(sqlInj);
        }
    


    }
}
