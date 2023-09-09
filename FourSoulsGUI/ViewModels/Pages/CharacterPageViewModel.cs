using FourSoulsDataConnection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsGUI
{
    public class CharacterPageViewModel : BaseViewModel
    {
        #region Private Members

        private List<Character> allCharacters;

        #endregion

        #region Public Properties

        public List<Character> AllCharacters
        {
            get => allCharacters;
            set
            {
                allCharacters = value;
                OnPropertyChanged(nameof(AllCharacters));
            }
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public CharacterPageViewModel()
        {
            AllCharacters = FourSoulsData.AllCharacters.Value.OrderByDescending(p => p.GamesPlayed ??= 0).ToList();
        }
        
    

        #endregion

        #region Private Helpers

        #endregion
    }
}
