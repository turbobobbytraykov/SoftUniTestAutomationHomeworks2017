using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasicTests
{
    [TestFixture]
    public class QAAutomationTests
    {
        /// <summary>
        /// Write a test that open browser and navigate to http://www.softuni.bg. Then by using navigation bar navigate to QA Automation course page. 
        /// Assert that there are two heading tags<h1> and<h2> that contains "Курс QA Automation - март 2017"
        /// </summary>
        [Test]
        public void TestQAAutomationCoursePageHeadings()
        {

            string coursesMenuItemLinkSelector = "//ul[contains(@class, 'nav-list')]/li//span[text() = 'Обучения']/ancestor::a";
            string qaAutomationCourseLinkSelector = "//ul[contains(@class, 'category-list sub-menu')]/li/a[text() = 'QA Automation - март 2017']";

            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://www.softuni.bg");

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(coursesMenuItemLinkSelector)));
                IWebElement coursesMenuItemLink = driver.FindElement(By.XPath(coursesMenuItemLinkSelector));
                coursesMenuItemLink.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(qaAutomationCourseLinkSelector)));

                var qaAutomationCourseLink = driver.FindElement(By.XPath(qaAutomationCourseLinkSelector));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", qaAutomationCourseLink);
                qaAutomationCourseLink.Click();

                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("Курс", StringComparison.OrdinalIgnoreCase));

                var courseNameHeadings = driver.FindElements(By.XPath("//h1[contains(text(),'QA Automation - март 2017')]"));
                Assert.That(courseNameHeadings.Count, Is.EqualTo(2));
            }
        }
    }
}
