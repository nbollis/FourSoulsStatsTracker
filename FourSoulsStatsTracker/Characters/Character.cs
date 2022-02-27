using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class Character : Engine
    {
        protected int wins;
        protected int losses;
        protected double winRate;
        protected double averageSouls;
        protected List<Game> allGames { get; }
        protected string characterName;
        public static string[] characterNames = new string[] {"Isaac", "Cain", "Maggy", "Judas", "Samson", "Eve", "Lilith", "Blue Baby",
            "Lazarath", "The Forgotten", "Eden", "The Lost", "The Keeper", "Axazel", "Apollyon", "Guppy", "Bum-Bo", "Whore of Babylon",
            "Dark Judas", "Tapeworm", "Bethany", "Jacob & Esau", "The Broken", "The Hoarder", "The Duantless", "The Deceiver", "The Savage",
            "The Curdled", "The Harlot", "The Soiled", "The Enigma", "The Fettered", "The Capricious", "The Baleful", "The Miser", "The Benighted",
            "The Empty", "The Zealot", "The Deserter", "Ash", "Guy Spelunky", "The Silent", "Captain Viridian", "The Knight", "Pink Knight",
            "Boyfriend", "Psycho Goreman", "Blind Johnny", "Salad Fingers", "Blue Archer", "Quote", "Crewmate", "Bum-Bo The Weird", "Steven",
            "Johnny", "Baba", "Edmund", "Flash Isaac"};

        // TODO loads character data from file
        public static List<Character> LoadData()
        {
            var characters = new List<Character>();
            return characters;
        }

        // TODO prints character data to file
        public static void PrintCharacters(List<Character> characters)
        {

        }


        public void PostgameCalculations()
        {
            this.CalculateWinRate();
            this.CalculateAverageSouls();
        }
        private void CalculateWinRate()
        {
            int winCount = 0;
            int gameCount = 0;
            int lossCount = 0;
            foreach (var game in this.allGames)
            {
                gameCount = gameCount + 1;
                for (int i = 0; i < game.gameDataByPlayer.Count(); i++)
                {
                    if (game.gameDataByPlayer[i].characterPlayed == this.characterName)
                    {
                        if (game.gameDataByPlayer[i].souls == 4)
                            winCount++;
                        else
                            lossCount++;
                    }
                }
            }
            wins = winCount;
            losses = lossCount++;
            winRate = Math.Round((double)(wins / gameCount), 2);
        }

        private void CalculateAverageSouls()
        {
            int soulCount = 0;
            int gameCount = 0;
            foreach (var game in this.allGames)
            {
                gameCount = gameCount + 1;
                for (int i = 0; i < game.gameDataByPlayer.Count(); i++)
                {
                    if (game.gameDataByPlayer[i].characterPlayed == this.characterName)
                    {
                        soulCount = soulCount + game.gameDataByPlayer[i].souls;
                    }
                }
            }
            averageSouls = soulCount / gameCount;
        }

        public void AddWinLoss(Game game)
        {

        }
        public string[] LoadCharacterNames()
        {
            return characterNames;
        }
    }
}
