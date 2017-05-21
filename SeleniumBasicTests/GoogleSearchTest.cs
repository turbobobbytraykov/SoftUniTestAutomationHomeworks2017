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
    class GoogleSearchTest
    {
        /// <summary>
        /// Write a test that opens a browser and navigates to http://www google.com. Then search for the best browser automation tool "Selenium". Click on first link and check if browser will open http://www.seleniumhq.org.
        /// Assert that title is "Selenium - Web Browser Automation".
        /// </summary>
        [Test]
        public void TestGoogleSearch()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                //Notice navigation is slightly different than the Java version
                //This is because 'get' is a keyword in C#
                driver.Navigate().GoToUrl("http://www.google.com/");

                // Find the text input element by its name
                IWebElement query = driver.FindElement(By.Name("q"));

                // Enter something to search for
                query.SendKeys("Selenium");

                // Now submit the form. WebDriver will find the form for us from the element
                query.Submit();
                // Google's search is rendered dynamically with JavaScript.
                // Wait for the page to load, timeout after 10 seconds
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("Selenium", StringComparison.OrdinalIgnoreCase));

                IWebElement firstResult = driver.FindElement(By.CssSelector("div#search div.g:first-of-type a:first-of-type"));
                firstResult.Click();
                wait.Until(d => !d.Title.ToLowerInvariant().Contains("google"));

                // Should see: "Cheese - Google Search" (for an English locale)
                Console.WriteLine("Page title is: " + driver.Title);
                Assert.That(driver.Title, Is.EqualTo("Selenium - Web Browser Automation"));
            }
        }
    }
}
