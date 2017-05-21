using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasicTests
{
    [TestFixture]
    public class DemoQARegistrationPageTests
    {
        /// <summary>
        /// 5.	DemoQA Registration page
        /// Write a test that navigate to http://www.demoqa.com and open registration page.
        /// Assert that registration page is open.
        /// </summary>
        [Test]
        public void TestNavigationToRegistrationPage()
        {
            string coursesMenuItemLinkSelector = "//ul[contains(@class, 'nav-list')]/li//span[text() = 'Обучения']/ancestor::a";
            string qaAutomationCourseLinkSelector = "//ul[contains(@class, 'category-list sub-menu')]/li/a[text() = 'QA Automation - март 2017']";

            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://www.demoqa.com");

                IWebElement registrationPageLink = driver.FindElement(By.XPath("//a[text() = 'Registration']"));
                registrationPageLink.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("Registration", StringComparison.OrdinalIgnoreCase));

                Assert.Multiple(() =>
                {
                    Assert.That(driver.FindElement(By.XPath("//ol/li[contains(@class, 'active')]/*[text() = 'Registration']")), Is.Not.Null);
                    Assert.That(driver.FindElement(By.XPath("//h1[text() = 'Registration']")), Is.Not.Null);
                });
            }
        }

    }
}
