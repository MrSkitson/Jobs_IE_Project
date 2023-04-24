
Feature: Save jobs for Automation Engineer
  As a user
  I want to save a list of jobs for Automation Engineer
  So that I can review them later

  Scenario: Save jobs for Automation Engineer
    Given I am on the jobs.ie website
    When I search for "Automation Engineer"
    Then I should see a list of jobs
    When I save the list of jobs to a file
    Then the file should contain job titles, salary levels and company names
