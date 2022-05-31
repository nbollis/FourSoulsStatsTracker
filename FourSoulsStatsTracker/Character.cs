using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    public class Character : Engine
    {
        public static List<Character> AllCharacters { get; set; }
        public static List<FourSoulsGame> AllGames { get; set; }
        public static readonly string[] characterNames = new string[] {"Isaac", "Cain", "Maggy", "Judas", "Samson", "Eve", "Lilith", "Blue Baby",
            "Lazarus", "The Forgotten", "Eden", "The Lost", "The Keeper", "Azazel", "Apollyon", "Guppy", "Bum-Bo", "Whore of Babylon",
            "Dark Judas", "Tapeworm", "Albert", "Bethany", "Jacob & Esau", "The Broken", "The Hoarder", "The Duantless", "The Deceiver", "The Savage",
            "The Curdled", "The Harlot", "The Soiled", "The Enigma", "The Fettered", "The Capricious", "The Baleful", "The Miser", "The Benighted",
            "The Empty", "The Zealot", "The Deserter", "Ash", "Guy Spelunky", "The Silent", "Captain Viridian", "The Knight", "Pink Knight",
            "Boyfriend", "Psycho Goreman", "Blind Johnny", "Salad Fingers", "Blue Archer", "Quote", "Crewmate", "Bum-Bo The Weird", "Steven",
            "Johnny", "Baba", "Edmund", "Flash Isaac"};
        private int wins;
        private int losses;
        private int gamesPlayed;
        private double winRate;
        private double averageSouls;
        private int cumulativeSouls;
        private string characterName;
        private Dictionary<string, (int win, int neither, int lose)> winRateByCharacter { get; set; }
        private Dictionary<string, (int win, int neither, int lose)> winRateByCharacterTwoPlayers { get; set; }
        private Dictionary<string, (int win, int neither, int lose)> winRateByCharacterThreePlayers { get; set; }
        private Dictionary<string, (int win, int neither, int lose)> winRateByCharacterFourPlayers { get; set; }

        public Character(string name = "ChangeMe", int win = 0, int lose = 0)
        {
            characterName = name;
            wins = win;
            losses = lose;
            winRateByCharacter = new();
            winRateByCharacterTwoPlayers = new();
            winRateByCharacterThreePlayers = new();
            winRateByCharacterFourPlayers = new();
            foreach (var character in characterNames)
            {
                winRateByCharacter.Add(character, (0, 0, 0));
                winRateByCharacterTwoPlayers.Add(character, (0, 0, 0));
                winRateByCharacterThreePlayers.Add(character, (0, 0, 0));
                winRateByCharacterFourPlayers.Add(character, (0, 0, 0));
            }
        }

        // Loads in characters and parses games to add their wins and losses
        public static List<Character> LoadData()
        {
            AllGames = games;
            AllCharacters = new List<Character>();
            // Initializes characters and searches 
            foreach (var name in characterNames)
            {
                AllCharacters.Add(new Character(name));
            }

            foreach (var character in AllCharacters)
            {
                character.CrunchNumbers(AllGames);
            }
            return AllCharacters;
        }

        // Itterates through a list of games and adds stats to a character's winRateByCharacter dictionaries
        public void CrunchNumbers(List<FourSoulsGame> games, bool playerSpecificCalc = false, string playerName = "empty")
        {

            List<FourSoulsGame> gamesWithCharacter = new();
            List<FourSoulsGame> wonGamesWithCharacter = new();
            List<FourSoulsGame> lostGamesWithCharacter = new();

            if (!playerSpecificCalc)
            {
                gamesWithCharacter = games.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(characterName))).ToList();
                wonGamesWithCharacter = games.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(characterName) && n.souls == 4)).ToList();
                lostGamesWithCharacter = games.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(characterName) && n.souls != 4)).ToList();
            }
            if (playerSpecificCalc)
            {
                gamesWithCharacter = games.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(characterName) && n.playerName.Equals(playerName))).ToList();
                wonGamesWithCharacter = games.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(characterName) && n.souls == 4 && n.playerName.Equals(playerName))).ToList();
                lostGamesWithCharacter = games.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(characterName) && n.souls != 4 && n.playerName.Equals(playerName))).ToList();
            }

            // Populates the dictionaries for each character vs each character
            for (int i = 0; i < AllCharacters.Count; i++)
            {
                if (AllCharacters[i].characterName.Equals(characterName)) continue;
                // (X, 0, 0) If Character[i] lost and we won
                var gamesWithSecondCharacterLosingAndFirstWon = wonGamesWithCharacter.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(AllCharacters[i].characterName) && n.souls != 4));
                // (0, X, 0) If Character[i] lost and main character lost
                var gamesWithBothCharactersLosing = lostGamesWithCharacter.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(AllCharacters[i].characterName) && n.souls != 4));
                // (0, 0, X) If Character[i] won, we lost
                var gamesWithSecondCharacterWinning = gamesWithCharacter.Where(p => p.gameDataByPlayer.Any(n => n.characterPlayed.Equals(AllCharacters[i].characterName) && n.souls == 4));

                if (winRateByCharacter.TryGetValue(AllCharacters[i].characterName, out (int, int, int) value))
                {
                    value.Item1 = gamesWithSecondCharacterLosingAndFirstWon.ToList().Count();
                    value.Item2 = gamesWithBothCharactersLosing.ToList().Count();
                    value.Item3 = gamesWithSecondCharacterWinning.ToList().Count();
                    this.winRateByCharacter[AllCharacters[i].characterName] = value;
                }

                if (winRateByCharacterTwoPlayers.TryGetValue(AllCharacters[i].characterName, out (int, int, int) val2))
                {
                    val2.Item1 = gamesWithSecondCharacterLosingAndFirstWon.Where(p => p.numberOfPlayers == 2).ToList().Count();
                    val2.Item2 = gamesWithBothCharactersLosing.Where(p => p.numberOfPlayers == 2).ToList().Count();
                    val2.Item3 = gamesWithSecondCharacterWinning.Where(p => p.numberOfPlayers == 2).ToList().Count();
                    this.winRateByCharacterTwoPlayers[AllCharacters[i].characterName] = val2;
                }

                if (winRateByCharacterThreePlayers.TryGetValue(AllCharacters[i].characterName, out (int, int, int) val3))
                {
                    val3.Item1 = gamesWithSecondCharacterLosingAndFirstWon.Where(p => p.numberOfPlayers == 3).ToList().Count();
                    val2.Item3 = gamesWithBothCharactersLosing.Where(p => p.numberOfPlayers == 3).ToList().Count();
                    val3.Item3 = gamesWithSecondCharacterWinning.Where(p => p.numberOfPlayers == 3).ToList().Count();
                    this.winRateByCharacterThreePlayers[AllCharacters[i].characterName] = val3;
                }

                if (winRateByCharacterFourPlayers.TryGetValue(AllCharacters[i].characterName, out (int, int, int) val4))
                {
                    val4.Item1 = gamesWithSecondCharacterLosingAndFirstWon.Where(p => p.numberOfPlayers == 4).Count();
                    val4.Item2 = gamesWithBothCharactersLosing.Where(p => p.numberOfPlayers == 4).Count();
                    val4.Item3 = gamesWithSecondCharacterWinning.Where(p => p.numberOfPlayers == 4).Count();
                    this.winRateByCharacterFourPlayers[AllCharacters[i].characterName] = val4;
                }
            }

            foreach (var game in gamesWithCharacter)
            {
                foreach (var data in game.gameDataByPlayer)
                {
                    if (data.characterPlayed.Equals(characterName))
                    {
                        cumulativeSouls += data.souls;
                    }
                }
            }

            wins = wonGamesWithCharacter.Count();
            losses = lostGamesWithCharacter.Count();
            gamesPlayed = gamesWithCharacter.Count();
            if (gamesPlayed != 0)
            {
                winRate = Math.Round((double)wins / (double)gamesPlayed,2);
                averageSouls = Math.Round((double)cumulativeSouls / (double)gamesPlayed,2);
            }
            int breakpoint = 0;
        }
        public static void PrintCharacters()
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Storage\Characters.txt");
            using (StreamWriter output = new StreamWriter(filepath))
            {
                output.WriteLine("CharacterName:Wins:Losses");
                foreach (var character in AllCharacters)
                {
                    output.WriteLine(character.ToString());
                }
            }
        }

        // Prints all data about characters
        public override string ToString()
        {
            string output = characterName + ":" + wins + ":" + losses;
            return output;
        }
    }
}
