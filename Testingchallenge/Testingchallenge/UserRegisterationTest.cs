using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testingchallenge
{

    [TestClass]
    public class UserRegisterationTest
    {

        [TestMethod]
        public void RegisterUsertestPass()
        {
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl("https://responsivefight.herokuapp.com/");
                By regobutton = By.Id("rego");
                webDriver.FindElement(regobutton).Click();
                By txtuname = By.Id("uname");                
                Random random = new Random();
                int num = random.Next(0, 1000);
                webDriver.FindElement(txtuname).SendKeys("Durgatest"+num.ToString());
                By txtpwd = By.Id("pwd");
                webDriver.FindElement(txtpwd).SendKeys("Test1#");
                By txtpswrepeat = By.Id("psw-repeat");
                webDriver.FindElement(txtpswrepeat).SendKeys("Test1#");
                By signupbtn = By.Id("signupbtn");
                webDriver.FindElement(signupbtn).Click();
                By loginmodal = By.Id("loginmodal");
                Assert.IsTrue(webDriver.FindElement(loginmodal).Displayed, "Test pass Reg compelete");
                webDriver.Close();
            }
            catch (Exception e)
            {
                Assert.Fail("test fail"+ e.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Quit();
            }



        }

        [TestMethod]
        public void RegisterUsertestemptyvalues()
        {
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl("https://responsivefight.herokuapp.com/");
                By regobutton = By.Id("rego");
                webDriver.FindElement(regobutton).Click();
                By txtuname = By.Id("uname");
                webDriver.FindElement(txtuname).SendKeys("");
                By txtpwd = By.Id("pwd");
                webDriver.FindElement(txtpwd).SendKeys("");
                By txtpswrepeat = By.Id("psw-repeat");
                webDriver.FindElement(txtpswrepeat).SendKeys("");
                By signupbtn = By.Id("signupbtn");
                webDriver.FindElement(signupbtn).Click();
                By popup = By.Id("popup");
                //Tested with null values for user name and password
                Assert.IsTrue(webDriver.FindElement(popup).Text== "User already exists", "invalid error message");
                Assert.Fail("Invalid error message when tested with nullvalue");
                
            }
            catch (Exception e)
            {
                Assert.Fail("test fail" + e.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Quit();
            }
        }

        [TestMethod]
        public void RegisterUsertestdifferentPassword()
        {
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl("https://responsivefight.herokuapp.com/");
                By regobutton = By.Id("rego");
                webDriver.FindElement(regobutton).Click();
                By txtuname = By.Id("uname");
                webDriver.FindElement(txtuname).SendKeys("Durgatest3");
                By txtpwd = By.Id("pwd");
                webDriver.FindElement(txtpwd).SendKeys("Test1#");
                By txtpswrepeat = By.Id("psw-repeat");
                webDriver.FindElement(txtpswrepeat).SendKeys("Test#");
                By signupbtn = By.Id("signupbtn");
                webDriver.FindElement(signupbtn).Click();
                By loginmodal = By.Id("loginmodal");
                Assert.IsTrue(webDriver.FindElement(loginmodal).Displayed, "Reg compelete");
                webDriver.Close();
            }
            catch (Exception e)
            {
                Assert.Fail("testfail");
                webDriver.Close();
            }



        }

        [TestMethod]
        public void RegisterUserAlreadyExiststest()
        {
            IWebDriver webDriver = new ChromeDriver();
            try
            {
                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl("https://responsivefight.herokuapp.com/");
                By regobutton = By.Id("rego");
                webDriver.FindElement(regobutton).Click();
                By txtuname = By.Id("uname");
                webDriver.FindElement(txtuname).SendKeys("Durgatest3");
                By txtpwd = By.Id("pwd");
                webDriver.FindElement(txtpwd).SendKeys("Test1#");
                By txtpswrepeat = By.Id("psw-repeat");
                webDriver.FindElement(txtpswrepeat).SendKeys("Test1#");
                By signupbtn = By.Id("signupbtn");
                webDriver.FindElement(signupbtn).Click();
                By popup = By.Id("popup");
                Assert.IsTrue(webDriver.FindElement(popup).Displayed, "useralreadyexist");
                webDriver.Close();
            }
            catch (Exception e)
            {
                Assert.Fail("test fail" + e.Message);
            }
            finally
            {
                webDriver.Close();
                webDriver.Quit();
            }

        }
    }
}
