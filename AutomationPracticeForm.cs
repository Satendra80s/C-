using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace CloudQATest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up Chrome WebDriver
            IWebDriver driver = new ChromeDriver();
            
            try
            {
                // Step 1: Navigate to the page
                driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

                // Wait for the page to load
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Step 2: Test Field 1 - First Name (text input)
                var firstNameField = wait.Until(d => d.FindElement(By.Id("first-name")));
                firstNameField.Clear();
                firstNameField.SendKeys("Test User");

                // Step 3: Test Field 2 - Email (email input)
                var emailField = driver.FindElement(By.Id("email"));
                emailField.Clear();
                emailField.SendKeys("testuser@example.com");

                // Step 4: Test Field 3 - Gender (radio button)
                var genderMaleRadioButton = driver.FindElement(By.Id("gender-male"));
                if (!genderMaleRadioButton.Selected)
                {
                    genderMaleRadioButton.Click();
                }

                // Step 5: Wait and validate the form
                var submitButton = driver.FindElement(By.Id("submit"));
                submitButton.Click();

                // Optionally: Assert that the form is submitted successfully (e.g., by checking the confirmation message)
                var confirmationMessage = wait.Until(d => d.FindElement(By.Id("confirmation-message")));
                Console.WriteLine(confirmationMessage.Text);

                // Wait before closing to observe result
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }
    }
}
