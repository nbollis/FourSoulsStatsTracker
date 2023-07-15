﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FourSoulsGUI.DI;
namespace FourSoulsGUI
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public ApplicationViewModel ApplicationViewModel => ViewModelApplication;

        /// <summary>
        /// The settings view model
        /// </summary>
        //public SettingsViewModel SettingsViewModel => ViewModelSettings;

        #endregion
    }
}
