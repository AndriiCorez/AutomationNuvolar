// <copyright file="IPage.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

namespace UILayerFramework.Pages
{
    /// <summary>
    /// Interface designed to be implemented by Page Objects classes
    /// </summary>
    interface IPage
    {
        string GetPageTitle();
        string GetPageUrl();
        void RefreshPage();
    }
}
