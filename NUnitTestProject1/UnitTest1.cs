using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

//Test for Assignemnt 2
namespace WebApp_Test
{
    public static class ChromeDriverAddress
    {
        public static string location = "/usr/local/bin";
    }

    public class Browser_ops
    {
        IWebDriver webDriver;

        public void Init_Browser()
        {
            ChromeOptions option = new ChromeOptions();
            option.BinaryLocation = "/Applications/Google Chrome.app/Contents/MacOS/Google Chrome";
            webDriver = new ChromeDriver(option);
            webDriver.Manage().Window.Maximize();

        }

        public string Title
        {
            get { return webDriver.Title; }
        }

        public void Goto(string url)
        {
            webDriver.Url = url;
        }

        public void Close()
        {
            webDriver.Quit();
        }

        public IWebDriver getDriver
        {

            get { return webDriver; }

        }
    }

    class CookieConsent //testing that clicking accept cookies gets rid of the cookie consent banner.
    {
        Browser_ops brow = new Browser_ops();
        IWebDriver driver;
        String test_url = "https://localhost:5001";



        [SetUp]
        public void start_browser()
        {
            brow.Init_Browser();
        }

        [Test]
        public void test_Cookie_Accept()
        {
            brow.Goto(test_url);
            System.Threading.Thread.Sleep(4000);
            driver = brow.getDriver;

            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"cookieConsent\"]/div/div[2]/div/button"));
            element.Click();
            System.Threading.Thread.Sleep(4000);
        }

        [TearDown]

        public void close_Browser()
        {
            brow.Close();
        }

    }

    class addPerson //testing adding a person.
    {
        Browser_ops brow = new Browser_ops();
        IWebDriver driver;
        String test_url = "https://localhost:5001";



        [SetUp]
        public void start_browser()
        {
            brow.Init_Browser();
        }

        [Test]
        public void test_addPerson() //testing that a person can be added and then shows up on the homepage list
        {
            brow.Goto(test_url);

            driver = brow.getDriver;

            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"cookieConsent\"]/div/div[2]/div/button"));
            element.Click();

            IWebElement addelement = driver.FindElement(By.XPath("/ html / body / nav / div / div[2] / ul / li[3] / a"));
            addelement.Click();


            IWebElement nameBox = driver.FindElement(By.XPath("//*[@id=\"person_form\"]/p[1]/input"));
            nameBox.SendKeys("Test Person");


            IWebElement jobBox = driver.FindElement(By.Name("jobId"));
            SelectElement dropdown = new SelectElement(jobBox);
            dropdown.SelectByText("Software Engineer");

            IWebElement salaryBox = driver.FindElement(By.Name("salary"));
            salaryBox.SendKeys("1000");

            driver.FindElement(By.Id("submit")).Submit();


            System.Threading.Thread.Sleep(4000);


        }

        [TearDown]

        public void close_Browser()
        {
            brow.Close();
        }

    }


    class removePerson //testing that the first person can be removed from the list. 
    {
        Browser_ops brow = new Browser_ops();
        IWebDriver driver;
        String test_url = "https://localhost:5001";



        [SetUp]
        public void start_browser()
        {
            brow.Init_Browser();
        }

        [Test]
        public void test_removePerson()
        {
            brow.Goto(test_url);

            driver = brow.getDriver;

            IWebElement remove = driver.FindElement(By.XPath("//*[@id=\"person_row_0\"]/td[6]/a"));
            remove.Click();


            System.Threading.Thread.Sleep(4000);
        }

        [TearDown]

        public void close_Browser()
        {
            brow.Close();
        }

    }

    class tabLinks //testing navigation between tabs in the navigation bar
    {
        Browser_ops brow = new Browser_ops();
        IWebDriver driver;
        String test_url = "https://localhost:5001";

        [SetUp]
        public void start_browser()
        {
            brow.Init_Browser();
            brow.Goto(test_url);
            driver = brow.getDriver;
            driver.FindElement(By.XPath("//*[@id=\"cookieConsent\"]/div/div[2]/div/button")).Click();
        }

        [Test]
        public void test_tabLinks()
        {
            driver.FindElement(By.LinkText("List Persons")).Click();
            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.LinkText("List Jobs")).Click();

            driver.FindElement(By.LinkText("Add Person")).Click();


            driver.FindElement(By.LinkText("Add Job")).Click();


            driver.FindElement(By.LinkText("Edit Person")).Click();
            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.LinkText("Web Application")).Click();
            System.Threading.Thread.Sleep(1000);


        }

        [TearDown]

        public void close_Browser()
        {
            brow.Close();
        }

    }

    class editPerson //testing editing a person form
    {
        Browser_ops brow = new Browser_ops();
        IWebDriver driver;
        String test_url = "https://localhost:5001";

        [SetUp]
        public void start_browser()
        {
            brow.Init_Browser();
            brow.Goto(test_url);
            driver = brow.getDriver;
            driver.FindElement(By.XPath("//*[@id=\"cookieConsent\"]/div/div[2]/div/button")).Click();
        }


        [Test]
        public void test_editPerson()
        {
            driver.FindElement(By.LinkText("Edit Person")).Click();

            IWebElement idBox = driver.FindElement(By.Name("id"));
            idBox.SendKeys("1");

            IWebElement nameBox = driver.FindElement(By.Name("name"));
            nameBox.SendKeys("Name Change");


            IWebElement jobBox = driver.FindElement(By.Name("jobId"));
            SelectElement dropdown = new SelectElement(jobBox);
            dropdown.SelectByText("Software Engineer");

            IWebElement salaryBox = driver.FindElement(By.Name("salary"));
            salaryBox.SendKeys("1000");

            driver.FindElement(By.Id("submit")).Submit();


            System.Threading.Thread.Sleep(4000);

        }

        [TearDown]

        public void close_Browser()
        {
            brow.Close();
        }
    }

}
