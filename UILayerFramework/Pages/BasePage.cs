// <copyright file="BasePage.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using OpenQA.Selenium;

namespace UILayerFramework.Pages
{
    /// <summary>
    /// Class contains common methods for Page Objects and designed to be a Parent class
    /// </summary>
    public class BasePage : IPage
    {
        protected static readonly string MAIN_PAGE_TITLE = "Facebook - Log In or Sign Up";
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver) => _driver = driver;

        #region Get's

        /// <summary>
        /// Gets a title of current web page
        /// </summary>
        /// <returns>Title</returns>
        public string GetPageTitle() => _driver.Title;

        /// <summary>
        /// Gets an URL of current web page
        /// </summary>
        /// <returns>URL</returns>
        public string GetPageUrl() => _driver.Url;

        #endregion

        #region Actions
        /// <summary>
        /// Refreshes current web page
        /// </summary>
        public void RefreshPage() => _driver.Navigate().Refresh();

        #endregion

    }
}
