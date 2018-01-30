using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UILayerFramework.Tests;
using UILayerFramework.Pages;
using NUnit.Framework;

namespace FacebookAutomationTest.Steps
{
    [Binding]
    public class AccountRegistrationSteps
    {
        #region Given's

        [Given(@"I open the main page")]
        public void GivenIOpenTheMainPage()
        {
            var test = new BaseTest(ConfigurationManager.AppSettings["applicationUrl"]);

            ScenarioContext.Current.Set(new LoginSignupPage(test.driver));
            ScenarioContext.Current.Set(test);
        }

        [Given(@"I have entered the following values to the registration form")]
        public void GivenIHaveEnteredTheFollowingValuesToTheRegistrationForm(Table table)
        {
            dynamic account = table.CreateDynamicInstance();

            ScenarioContext.Current.Get<LoginSignupPage>().
                SetFirstName(account.Fname).
                SetLastName(account.Sname).
                SetMobileOrEmail(account.Email.ToString()).
                ReenterMobileOrEmail(account.Email.ToString()).
                SetNewPassword(account.Password).
                SetGender(GenderHelper.GetGender(account.Gender));
        }

        [Given(@"I have entered the following values to the registration form without reentering email phone field")]
        public void GivenIHaveEnteredTheFollowingValuesToTheRegistrationFormWithoutReenteringEmailPhoneField(Table table)
        {
            dynamic account = table.CreateDynamicInstance();

            ScenarioContext.Current.Get<LoginSignupPage>().
                SetFirstName(account.Fname).
                SetLastName(account.Sname).
                SetMobileOrEmail(account.Email.ToString()).
                SetNewPassword(account.Password).
                SetGender(GenderHelper.GetGender(account.Gender));
        }

        [Given(@"I have entered ""(.*)"" first name, ""(.*)"" second name, ""(.*)"" in email and '(.*)' password")]
        public void GivenIHaveEnteredFirstNameSecondNameInEmailAndPassword(string firstName, string secondName, string email, string password)
        {
            ScenarioContext.Current.Get<LoginSignupPage>().
                SetFirstName(firstName).
                SetLastName(secondName).
                SetMobileOrEmail(email).
                ReenterMobileOrEmail(email).
                SetNewPassword(password);
        }

        [Given(@"I have entered default values in the fields and specific with '(.*)' password")]
        public void GivenIHaveEnteredDefaultValuesInTheFieldsAndSpecificWithPassword(string password)
        {
            string randomEmail = EmailGenerator.GenerateRandomEmail();
            ScenarioContext.Current.Get<LoginSignupPage>().
                SetFirstName("John").
                SetLastName("Corezina").
                SetMobileOrEmail(randomEmail).
                ReenterMobileOrEmail(randomEmail).
                SetNewPassword(password).
                SetGender(LoginSignupPage.Gender.Female);
        }

        [Given(@"I have entered default values in the fields and specific with '(.*)' email or phone value")]
        public void GivenIHaveEnteredDefaultValuesInTheFieldsAndSpecificWithEmailOrPhoneValue(string emailPhone)
        {
            ScenarioContext.Current.Get<LoginSignupPage>().
                SetFirstName("John").
                SetLastName("Corezina").
                SetMobileOrEmail(emailPhone).                
                SetNewPassword("password1!").
                SetGender(LoginSignupPage.Gender.Female);
        }

        [Given(@"I have entered default values in the fields and specific with '(.*)' first name and '(.*)' second name values")]
        public void GivenIHaveEnteredDefaultValuesInTheFieldsAndSpecificWithFirstNameAndSecondNameValues(string firstName, string secondName)
        {
            string randomEmail = EmailGenerator.GenerateRandomEmail();
            ScenarioContext.Current.Get<LoginSignupPage>().
                SetFirstName(firstName).
                SetLastName(secondName).
                SetMobileOrEmail(randomEmail).
                ReenterMobileOrEmail(randomEmail).
                SetNewPassword("paSS3@").
                SetGender(LoginSignupPage.Gender.Female);
        }


        #endregion

        #region When's

        [When(@"I click create account button")]
        public void WhenIClickCreateAccountButton()
        {
            ScenarioContext.Current.Get<LoginSignupPage>().ClickCreateAccountBtn();
        }

        [When(@"I click on second name field")]
        public void WhenIClickOnSecondNameField()
        {
            ScenarioContext.Current.Get<LoginSignupPage>().ClickSecondNameField();
        }

        [When(@"I click Yes button on birthday confirmation window")]
        public void WhenIClickYesButtonOnBirthdayConfirmationWindow()
        {
            ScenarioContext.Current.Get<LoginSignupPage>().ClickYesOnBirthdayConfirmationWindow();
        }


        #endregion

        #region Then's

        [Then(@"I see a pop-up with '(.*)' title")]
        public void ThenISeeAPop_UpWithTitle(string expectedTitle)
        {
            string actualTitle = ScenarioContext.Current.Get<LoginSignupPage>().
                GetConfirmBirthdayPopupTitle();

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Then(@"I see a ""(.*)"" first name error")]
        public void ThenISeeAFirstNameError(string errorTextExpected)
        {
            string errorTextActual = ScenarioContext.Current.Get<LoginSignupPage>().GetFirstNameErrorTxt();
            Assert.AreEqual(errorTextExpected, errorTextActual);
        }

        [Then(@"I see a ""(.*)"" second name error")]
        public void ThenISeeASecondNameError(string errorTextExpected)
        {
            string errorTextActual = ScenarioContext.Current.Get<LoginSignupPage>().GetSecondNameErrorTxt();
            Assert.AreEqual(errorTextExpected, errorTextActual);
        }

        [Then(@"I see a ""(.*)"" phone mail error")]
        public void ThenISeeAPhoneMailError(string errorTextExpected)
        {
            string errorTextActual = ScenarioContext.Current.Get<LoginSignupPage>().GetEmailPhoneErrorTxt();
            Assert.AreEqual(errorTextExpected, errorTextActual);
        }

        [Then(@"I see a ""(.*)"" password error")]
        public void ThenISeeAPasswordError(string errorTextExpected)
        {
            string errorTextActual = ScenarioContext.Current.Get<LoginSignupPage>().GetPasswordErrorTxt();
            Assert.AreEqual(errorTextExpected, errorTextActual);
        }

        [Then(@"I see a ""(.*)"" gender error")]
        public void ThenISeeAGenderError(string errorTextExpected)
        {
            string errorTextActual = ScenarioContext.Current.Get<LoginSignupPage>().GetGenderErrorTxt();
            Assert.AreEqual(errorTextExpected, errorTextActual);
        }

        [Then(@"I see a ""(.*)"" general error")]
        public void ThenISeeAGeneralError(string errorTextExpected)
        {
            string errorTextActual = ScenarioContext.Current.Get<LoginSignupPage>().GetGeneralTopErrorTxt();
            Assert.AreEqual(errorTextExpected, errorTextActual);
        }


        #endregion



    }
}
