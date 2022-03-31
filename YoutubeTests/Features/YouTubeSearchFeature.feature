Feature: YoutubeSearchFeature In order to test search functionality on youtube
As a User
I want to ensure search functionality is working end to end
@mytag
Scenario: Youtube should search for the given keyword and should navigate to search results page
Given I have navigated to youtube website
And I have entered term as search keyword
When I press the search button
Then I should be navigated to search results page