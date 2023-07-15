using FourSoulsDataConnection.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsDataConnection
{
    public static class DataOperations
    {
        static ObservableCollection<string> AllPlayerNames(FourSoulsData data)
        {
            return data.AllPlayers.Value.Select(p => p.Name).ToObservableCollection();
        }

        static ObservableCollection<string> AllCharacterNames(FourSoulsData data)
        {
            return data.AllCharacters.Value.Select(p => p.Name).ToObservableCollection();
        }
    }
}
