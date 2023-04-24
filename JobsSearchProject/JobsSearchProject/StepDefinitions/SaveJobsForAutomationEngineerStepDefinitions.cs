using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace JobsSearchProject.StepDefinitions
{
    [Binding]
    public class SaveJobsForAutomationEngineerStepDefinitions
    {
        private IWebDriver driver;
        private string jobList;

        [Given(@"I am on the jobs\.ie website")]
        public void GivenIAmOnTheJobs_IeWebsite()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.jobs.ie/");
            Thread.Sleep(1000);
        }

        [When(@"I search for ""([^""]*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            var searchBox = driver.FindElement(By.Id("txtKeywords"));
            searchBox.SendKeys(searchTerm);
            searchBox.Submit();
        }

        [Then(@"I should see a list of jobs")]
        public void ThenIShouldSeeAListOfJobs()
        {
            var jobListElement = driver.FindElement(By.ClassName("jobList"));
            Assert.That(jobListElement.Displayed, Is.True);
            jobList = jobListElement.Text;
        }


        [When(@"I save the list of jobs to a file")]
        public void WhenISaveTheListOfJobsToAFile()
        {
            File.WriteAllText("joblist.txt", jobList);
        }
        public void ThenTheFileShouldContainJobTitlesSalaryLevelsAndCompanyNames()
        {
            var fileContents = File.ReadAllText("joblist.txt");
            Assert.That(fileContents, Does.Contain("Job Title"));
            Assert.That(fileContents, Does.Contain("Salary Level"));
            Assert.That(fileContents, Does.Contain("Company Name"));
        }
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
    }
