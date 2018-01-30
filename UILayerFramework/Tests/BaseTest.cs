// <copyright file="BaseTest.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UILayerFramework.Tests
{
    public class BaseTest : ITest
    {
        private string _url;
        private double _waitSeconds;
        private double _waitSecondsMin;
        public IWebDriver driver;

        private void Initialize(string url)
        {
            _url = url;
            _waitSeconds = 10;
            _waitSecondsMin = 1;
        }

        private void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(_url);
            driver.Manage().Window.Maximize();
        }

        private void TurnOnPageDefaultWait() => driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_waitSeconds);

        private void TurnOnElementDefaultWait() => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_waitSeconds);


        public BaseTest(string url)
        {
            if (_url == null && _waitSeconds <= 0 && _waitSecondsMin <= 0)
            {
                Initialize(url);
            }

            TestSetup();
            TurnOnElementDefaultWait();
            TurnOnPageDefaultWait();
        }

        /// <summary>
        /// Closes the browser and terminates driver processes
        /// </summary>
        public void TestCleanUp() => driver.Quit();
    }
}
