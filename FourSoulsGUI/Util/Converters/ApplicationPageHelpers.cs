using System;
using System.Diagnostics;
using System.Globalization;

namespace FourSoulsGUI
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Takes a <see cref="ApplicationPage"/> and a view model, if any, and creates the desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            // Find the appropriate page
            switch (page)
            {
                case ApplicationPage.EnterGamePage:
                    return new EnterGamePage(viewModel as EnterGamePageViewModel);

                case ApplicationPage.PlayerPage:
                    return new PlayerPage(viewModel as PlayerPageViewModel);

                case ApplicationPage.CharacterPage:
                    return new CharacterPage(viewModel as CharacterPageViewModel);

                case ApplicationPage.EditGamesPage:
                    return new EditGamePage(viewModel as EditGamePageViewModel);
                    

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {

            if (page is EnterGamePage)
                return ApplicationPage.EnterGamePage;
            if (page is PlayerPage)
                return ApplicationPage.PlayerPage;
            if (page is CharacterPage)
                return ApplicationPage.CharacterPage;
            if (page is EditGamePage)
                return ApplicationPage.EditGamesPage;

            // Alert developer of issue
            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
