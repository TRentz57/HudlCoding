//Created By Tyler Rentz for Hudl Interview
//Uses a page object model to store the elements from the pages I test

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HudlCoding
{
    public class Tests 
    {
        IWebDriver driver;
     
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            //driver = new ChromeDriver("C:\\Users\\Tyler\\source\\repos\\HudlCoding\\Drivers");
            driver.Manage().Window.Maximize();
            
        }
        //Tests that I can log in with correct Email and Pwd
        [Test]
        public void LoginCorrectly()
        {
            driver.Navigate().GoToUrl("https://www.hudl.com/login");
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.EnterEmail();
            loginPage.EnterPassword();
            ClickLoginButtonPass();
        }
        //Tests that I cant log in if only Email field is filled out
        [Test]
        public void LoginIncorrectlyOnlyEmail()
        {
            driver.Navigate().GoToUrl("https://www.hudl.com/login");
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.EnterEmail();
            loginPage.ClickLoginButtonFail();

        }
        //Tests that I cant log in if only password field is filled out
        [Test]
        public void LoginIncorrectlyOnlyPassword()
        {
            driver.Navigate().GoToUrl("https://www.hudl.com/login");
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.EnterPassword();
            loginPage.ClickLoginButtonFail();

        }
        //Tests that I cant log in if email is correct but pwd is not 
        [Test]
        public void LoginIncorrectlyGoodEmailBadPwd()
        {
            driver.Navigate().GoToUrl("https://www.hudl.com/login");
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.EnterEmail();
            loginPage.EnterWrongPassword();
            loginPage.ClickLoginButtonFail();

        }
        //Tests that I cant log in if email is incorrect but password is correct
        [Test]
        public void LoginIncorrectlyBadEmailGoodPwd()
        {
            driver.Navigate().GoToUrl("https://www.hudl.com/login");
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.EnterWrongEmail();
            loginPage.EnterPassword();
            loginPage.ClickLoginButtonFail();

        }
        //Tests that I cant do a simple SQL inj inside the email field (this is an edge case)
        [Test]
        public void SqlInjEmail()
        {
            driver.Navigate().GoToUrl("https://www.hudl.com/login");
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.EnterSQlInjEmail();
            loginPage.ClickLoginButtonFail();

        }
        //Tests that I cant do a simple SQL inj inside the password field (this is an edge case)
        [Test]
        public void SqlInjPwd()
        {
            driver.Navigate().GoToUrl("https://www.hudl.com/login");
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.EnterSQlInjPwd();
            loginPage.ClickLoginButtonFail();

        }

        [TearDown]
        public void Close()
        {
            driver.Close();
        } 
       //Tests that when I click the login btn it navs me to the home page and verifies a button on the home page. 
        public void ClickLoginButtonPass()
        {
           
            PageObjectModel.LoginPage loginPage = new PageObjectModel.LoginPage(driver);
            loginPage.loginBtn.Click();
             
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://www.hudl.com/home");
            
           PageObjectModel.HomePage homePage = new PageObjectModel.HomePage(driver);

            string homeBtnTxt= homePage.homeBtn.Text;
           Console.WriteLine(homeBtnTxt);
            if (homeBtnTxt == "Home")
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
      

        }
       
    }
}