using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using YouTubeTests.PageObjects;

namespace YouTubeTests.StepDefinitions
{
    /// <summary>
    /// Feature step definition for youtube search.
    /// </summary>
    [Binding]
    public class YouTubeSearchFeatureSteps : IDisposable
    {
        private readonly ScenarioContext _scenarioContext;

        private YouTubePage page;
        private string searchString = string.Empty;

        public YouTubeSearchFeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            IWebDriver webDriver = new ChromeDriver();
            page = new (webDriver);
        }

        [Given(@"I have navigated to youtube website")]
        public void GivenIHaveNavigatedToYoutubeWebsite()
        {
            page.NavigateToPage();
            Assert.IsTrue(page.WebDriver.Title.ToLower().Contains("youtube"));
        }

        [Given(@"I have entered (.*) as search keyword")]
        public void GivenIHaveEnteredTermAsSearchKeyword(string searchString)
        {
            this.searchString = searchString;
            page.SetSearchText(this.searchString);
        }

        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            page.ClickSearch();
        }

        [Then(@"I should be navigated to search results page")]
        public void ThenIShouldBeNavigatedToSearchResultsPage()
        {
            page.Wait.Until(ExpectedConditions.TitleContains(searchString));

            Assert.IsTrue(page.WebDriver.Url.ToLower().Contains(searchString));
            Assert.IsTrue(page.WebDriver.Title.ToLower().Contains(searchString));
        }

        public void Dispose()
        {
            if (page != null)
            {
                page.Dispose();
                page = null;
            }
        }
    }
}