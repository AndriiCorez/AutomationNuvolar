// <copyright file="LoginSignupPage.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace UILayerFramework.Pages
{
    /// <summary>
    /// Page Object reflects Login and Signup page of the application
    /// </summary>
    public class LoginSignupPage : BasePage
    {
        
        private readonly string confirmBDayTitle = "Confirm Your Birthday";
        private readonly string palceholder = "placeholder";

        #region PageFactory

        [FindsBy(How = How.CssSelector, Using = "input[name='firstname']")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='lastname']")]
        private IWebElement SecondName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='reg_email__']")]
        private IWebElement EmailOrPhone { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name='reg_email_confirmation__']")]
        private IWebElement ReenterEmailOrPhone { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[type='password'][name='reg_passwd__']")]
        private IWebElement NewPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='1'][name='sex']")]
        private IWebElement FemaleGender { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='2'][name='sex']")]
        private IWebElement MaleGender { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement CreateAccountBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='u_0_5']")]
        private IWebElement ConfirmBDayPopupTitle { get; set; }

        #region Errors

        [FindsBy(How = How.XPath, Using = "//div[1]/div[4]/div[3]/div/div/div")]
        private IWebElement FirstNameError { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, '_5633') and contains(@class, '_5634') and contains(@class, '_53ij')]")]
        private IWebElement SecondNameError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, '_5633') and contains(@class, '_5634') and contains(@class, '_53ij')]")]
        private IWebElement EmailPhoneError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, '_5633') and contains(@class, '_5634') and contains(@class, '_53ij')]")]
        private IWebElement EmailPhoneReenterError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, '_5633') and contains(@class, '_5634') and contains(@class, '_53ij')]")]
        private IWebElement PasswordError { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, '_5633') and contains(@class, '_5634') and contains(@class, '_53ij')]")]
        private IWebElement GenderError { get; set; }

        [FindsBy(How = How.Id, Using = "reg_error_inner")]
        private IWebElement GeneralTopPageError { get; set; }

        #endregion

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'layerConfirm') and contains(@type, 'submit')]")]
        private IWebElement BirthdayConfirmationYesBtn { get; set; }

        #endregion

        public LoginSignupPage(IWebDriver driver)
            : base(driver)
        {
            if (!MAIN_PAGE_TITLE.Equals(GetPageTitle()))
                throw new Exception("This is not a '" + MAIN_PAGE_TITLE + "' main page:" + GetPageTitle());

            PageFactory.InitElements(_driver, this);
        }

        public enum Gender
        {
            /// <summary>
            /// Used in case there should no gender to be selected
            /// </summary>
            None,

            /// <summary>
            /// Female gender
            /// </summary>
            Female,

            /// <summary>
            /// Male gender
            /// </summary>
            Male
        }

        #region Action's

        /// <summary>
        /// Populates First Name field
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage SetFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);
            return this;
        }

        /// <summary>
        /// Populates Last Name field
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage SetLastName(string lastName)
        {
            SecondName.SendKeys(lastName);
            return this;
        }

        /// <summary>
        /// Populates Phone number or Email field
        /// </summary>
        /// <param name="mobileOrEmail"></param>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage SetMobileOrEmail(string mobileOrEmail)
        {
            EmailOrPhone.SendKeys(mobileOrEmail);
            return this;
        }

        /// <summary>
        /// Populates Phone number or Email reentering field
        /// </summary>
        /// <param name="mobileOrEmail"></param>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage ReenterMobileOrEmail(string mobileOrEmail)
        {
            ReenterEmailOrPhone.SendKeys(mobileOrEmail);
            return this;
        }

        /// <summary>
        /// Populates password field
        /// </summary>
        /// <param name="password"></param>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage SetNewPassword(string password)
        {
            NewPassword.SendKeys(password);
            return this;
        }

        /// <summary>
        /// Selects gender radiobutton
        /// </summary>
        /// <param name="gender"></param>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage SetGender(Gender gender)
        {
            if (gender == Gender.Female)
                FemaleGender.Click();
            else if (gender == Gender.Male)
                MaleGender.Click();

            return this;
        }

        /// <summary>
        /// Clicks Create Account button
        /// </summary>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage ClickCreateAccountBtn()
        {
            CreateAccountBtn.Click();
            return this;
        }

        /// <summary>
        /// Clicks on a Second Name Field
        /// </summary>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage ClickSecondNameField()
        {
            SecondName.Click();
            return this;
        }

        /// <summary>
        /// Clicks Yes button on Birthday confirmation pop-up window
        /// </summary>
        /// <returns>LoginSignupPage page object</returns>
        public LoginSignupPage ClickYesOnBirthdayConfirmationWindow()
        {
            BirthdayConfirmationYesBtn.Click();
            return this;
        }

        #endregion

        #region Get's        

        /// <summary>
        /// Gets the title of Birthday confirmation pop-up window waiting until text is not an empty string
        /// </summary>
        /// <returns>Title</returns>
        public string GetConfirmBirthdayPopupTitle()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//*[@id='u_0_5']")).Text.Equals(confirmBDayTitle));
            return ConfirmBDayPopupTitle.Text;
        }

        /// <summary>
        /// Gets the First name field error text
        /// </summary>
        /// <returns>Error text</returns>
        public string GetFirstNameErrorTxt() => FirstNameError.Text;

        /// <summary>
        /// Gets the Second name field error text
        /// </summary>
        /// <returns>Error text</returns>
        public string GetSecondNameErrorTxt() => SecondNameError.Text;

        /// <summary>
        /// Gets the Email or Phone field error text
        /// </summary>
        /// <returns>Error text</returns>
        public string GetEmailPhoneErrorTxt() => EmailPhoneError.Text;

        /// <summary>
        /// Gets the Password field error text
        /// </summary>
        /// <returns>Error text</returns>
        public string GetPasswordErrorTxt() => PasswordError.Text;

        /// <summary>
        /// Gets the Genders radiobuttons error text
        /// </summary>
        /// <returns>Error text</returns>
        public string GetGenderErrorTxt() => GenderError.Text;

        /// <summary>
        /// Gets the error text from the top of registration block waiting until text is not an empty string
        /// </summary>
        /// <returns>Error text</returns>
        public string GetGeneralTopErrorTxt()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//*[@id='reg_error_inner']")).Text != string.Empty);
            return GeneralTopPageError.Text;
        }

        #endregion 
    }
}
