using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static FourSoulsGUI.DI;

namespace FourSoulsGUI
{
    public class ApplicationViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.EnterGamePage;
        public BaseViewModel CurrentPageViewModel { get; set; }
        public EnterGamePageViewModel EnterGamePageViewModel { get; set; }
        public PlayerPageViewModel PlayerPageViewModel { get; set; }
        public CharacterPageViewModel CharacterPageViewModel { get; set; }
        public EditGamePageViewModel EditGamePageViewModel { get; set; }

        #endregion

        #region Commands

        public ICommand OpenEnterGamePageCommand { get; set; }
        public ICommand OpenPlayerPageCommand { get; set; }
        public ICommand OpenCharacterPageCommand { get; set; }
        public ICommand OpenEditGamePageCommand { get; set; }

        #endregion

        #region Constructor

        public ApplicationViewModel()
        {
            EnterGamePageViewModel = new();
            PlayerPageViewModel = new();
            CharacterPageViewModel = new();
            EditGamePageViewModel = new();

            OpenEnterGamePageCommand = new RelayCommand(OpenEnterGamePage);
            OpenPlayerPageCommand = new RelayCommand(OpenPlayerPage);
            OpenCharacterPageCommand = new RelayCommand(OpenCharacterPage);
            OpenEditGamePageCommand = new RelayCommand(OpenEditGamePage);
        }

        #endregion

        #region Helpers

        private void OpenEnterGamePage()
        {
            ViewModelApplication.GoToPage(ApplicationPage.EnterGamePage, EnterGamePageViewModel);
        }

        private void OpenPlayerPage()
        {
            ViewModelApplication.GoToPage(ApplicationPage.PlayerPage, PlayerPageViewModel);
        }

        private void OpenCharacterPage()
        {
            ViewModelApplication.GoToPage(ApplicationPage.CharacterPage, CharacterPageViewModel);
        }

        private void OpenEditGamePage()
        {
            ViewModelApplication.GoToPage(ApplicationPage.EditGamesPage, EditGamePageViewModel);
        }

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            // Set the view model
            CurrentPageViewModel = viewModel;

            // See if page has changed
            var different = CurrentPage != page;

            // Set the current page
            CurrentPage = page;

            // If the page hasn't changed, fire off notification
            // So pages still update if just the view model has changed
            if (!different)
                OnPropertyChanged(nameof(CurrentPage));
        }

        #endregion
    }
}
