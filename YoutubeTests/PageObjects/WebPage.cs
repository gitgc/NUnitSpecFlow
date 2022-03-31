using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace YouTubeTests.PageObjects
{
    /// <summary>
    /// Abstract WebPage with common utility code. Use this as starting point for all Page Object Models.
    /// </summary>
    public abstract class WebPage : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebPage"/> class.
        /// </summary>
        /// <param name="webDriver">The <see cref="IWebDriver"/> instance to use to access page in browser.</param>
        public WebPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        /// <summary>
        /// Gets the <see cref="IWebDriver"/> instance the page object will use.
        /// </summary>
        public IWebDriver WebDriver { get; }

        /// <summary>
        /// Gets or sets the timeout provided by the built in <see cref="WebPage.Wait"/> <see cref="WebDriverWait"/> instance to be adjusted.
        /// Default value is 5 seconds.
        /// </summary>
        public int WebDriverWaitTimeoutSeconds { get; set; } = 10;

        /// <summary>
        /// Gets a configured WebDriverWait instance.
        /// </summary>
        internal WebDriverWait Wait => new (WebDriver, TimeSpan.FromSeconds(WebDriverWaitTimeoutSeconds));

        /// <summary>
        /// Navigates to the page and leaves it ready for further interactions.
        /// </summary>
        public abstract void NavigateToPage();

        /// <inheritdoc/>
        public virtual void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
