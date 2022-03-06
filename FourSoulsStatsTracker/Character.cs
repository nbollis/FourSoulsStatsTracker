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
            "Lazarath", "The Forgotten", "Eden", "The Lost", "The Keeper", "Azazel", "Apollyon", "Guppy", "Bum-Bo", "Whore of Babylon",
            "Dark Judas", "Tapeworm", "Bethany", "Jacob & Esau", "The Broken", "The Hoarder", "The Duantless", "The Deceiver", "The Savage",
            "The Curdled", "The Harlot", "The Soiled", "The Enigma", "The Fettered", "The Capricious", "The Baleful", "The Miser", "The Benighted",
            "The Empty", "The Zealot", "The Deserter", "Ash", "Guy Spelunky", "The Silent", "Captain Viridian", "The Knight", "Pink Knight",
            "Boyfriend", "Psycho Goreman", "Blind Johnny", "Salad Fingers", "Blue Archer", "Quote", "Crewmate", "Bum-Bo The Weird", "Steven",
            "Johnny", "Baba", "Edmund", "Flash Isaac"};
        private int wins;
        private int losses;
        private double winRate;
        private double averageSouls;
        private string characterName;
        private Dictionary<string, (int win, int lose)> winRateByCharacter { get; set; }
        private Dictionary<string, (int win, int lose)> winRateByCharacterTwoPlayers { get; set; }
        private Dictionary<string, (int win, int lose)> winRateByCharacterThreePlayers { get; set; }
        private Dictionary<string, (int win, int lose)> winRateByCharacterFourPlayers { get; set; }

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
                winRateByCharacter.Add(character, (0, 0));
                winRateByCharacterTwoPlayers.Add(character, (0, 0));
                winRateByCharacterThreePlayers.Add(character, (0, 0));
                winRateByCharacterFourPlayers.Add(character, (0, 0));
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
        public void CrunchNumbers(List<FourSoulsGame> games)
        {
            string name = "";
            foreach (var game in games)
            {
                for (int i = 0; i < AllCharacters.Count; i++)
                {
                    name = AllCharacters[i].characterName;
                    // If this character is found in the game in question and won
                    if (game.gameDataByPlayer.Any(p => p.characterPlayed.Equals(this.characterName) && p.souls == 4))
                    {
                        if (i == 0)
                            this.wins += 1;
                        // If character[i] is found in the game but lost
                        if (game.gameDataByPlayer.Any(p => p.characterPlayed.Equals(name) && p.souls != 4))
                        {
                            if (winRateByCharacter.TryGetValue(name, out (int, int) value))
                            {
                                value.Item1 += 1;
                                this.winRateByCharacter[name] = value;
                            }
                            switch (Int32.Parse(game.ToString().Substring(0, 1)))
                            {
                                case 2:
                                    if (winRateByCharacterTwoPlayers.TryGetValue(name, out (int, int) val2))
                                    {
                                        val2.Item1 += 1;
                                        this.winRateByCharacter[name] = val2;
                                    }
                                    break;
                                case 3:
                                    if (winRateByCharacterThreePlayers.TryGetValue(name, out (int, int) val3))
                                    {
                                        val3.Item1 += 1;
                                        this.winRateByCharacter[name] = val3;
                                    }
                                    break;
                                case 4:
                                    if (winRateByCharacterFourPlayers.TryGetValue(name, out (int, int) val4))
                                    {
                                        val4.Item1 += 1;
                                        this.winRateByCharacter[name] = val4;
                                    }
                                    break;
                            }
                        }
                    }
                    // If this character is found in the game in question and lost
                    if (game.gameDataByPlayer.Any(p => p.characterPlayed.Equals(this.characterName) && p.souls != 4))
                    {
                        if (i == 0)
                            this.losses += 1;
                        // If character[i] is found in the game but won
                        if (game.gameDataByPlayer.Any(p => p.characterPlayed.Equals(name) && p.souls == 4))
                        {
                            if (winRateByCharacter.TryGetValue(name, out (int, int) value))
                            {
                                value.Item2 += 1;
                                this.winRateByCharacter[name] = value;
                            }
                            switch (Int32.Parse(game.ToString().Substring(0, 1)))
                            {
                                case 2:
                                    if (winRateByCharacterTwoPlayers.TryGetValue(name, out (int, int) val2))
                                    {
                                        val2.Item2 += 1;
                                        this.winRateByCharacter[name] = val2;
                                    }
                                    break;
                                case 3:
                                    if (winRateByCharacterThreePlayers.TryGetValue(name, out (int, int) val3))
                                    {
                                        val3.Item2 += 1;
                                        this.winRateByCharacter[name] = val3;
                                    }
                                    break;
                                case 4:
                                    if (winRateByCharacterFourPlayers.TryGetValue(name, out (int, int) val4))
                                    {
                                        val4.Item2 += 1;
                                        this.winRateByCharacter[name] = val4;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            int breakpoint = 0;
        }
        public static void PrintCharacters()
        {
            string filepath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\Characters.txt";
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
