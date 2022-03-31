using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace YouTubeTests.PageObjects
{
    /// <summary>
    /// Models youtube home and search page.
    /// </summary>
    public class YouTubePage : WebPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YouTubePage"/> class.
        /// </summary>
        /// <param name="webDriver">The <see cref="IWebDriver"/> instance to use.</param>
        public YouTubePage(IWebDriver webDriver)
            : base(webDriver)
        {
        }

        private By TextBoxSearchInputBy => By.XPath("//input[@id='search']");

        private IWebElement TextBoxSearchInput => WebDriver.FindElement(TextBoxSearchInputBy);

        private By BtnSearchBy => By.XPath("//button[@id='search-icon-legacy']");

        private IWebElement BtnSearch => WebDriver.FindElement(BtnSearchBy);

        /// <inheritdoc/>
        public override void NavigateToPage()
        {
            WebDriver.Navigate().GoToUrl("https://www.youtube.com");
        }

        /// <summary>
        /// Waits for the search textbox to appear, then sets the specified string.
        /// </summary>
        /// <param name="searchText">string to use as search text.</param>
        public void SetSearchText(string searchText)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(TextBoxSearchInputBy));
            TextBoxSearchInput.SendKeys(searchText);
        }

        /// <summary>
        /// Waits for the search button to appear, then clicks it.
        /// </summary>
        public void ClickSearch()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(BtnSearchBy));
            BtnSearch.Click();
            Wait.Until(ExpectedConditions.UrlContains("results"));
        }
    }
}
