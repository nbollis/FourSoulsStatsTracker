using System;
using System.Collections.Generic;

namespace FourSoulsDataConnection.DataBase
{
    public class MockedFourSoulsDataClient : IFourSoulsData
    {
        private FourSoulsData data = null;
        private int numberOfRecords = 0;

        public MockedFourSoulsDataClient(int numberOfRecords)
        {
            this.numberOfRecords = numberOfRecords;
        }

        public FourSoulsData Data
        {
            get => data ??= GetFourSoulsData();
            set => data = value;
        }

        private FourSoulsData GetFourSoulsData()
        {
            FourSoulsData data = new();
            data.AllCharacters = new Lazy<List<Character>>(() => MockData.GetCharacters(numberOfRecords));
            data.AllPlayers = new Lazy<List<Player>>(() => MockData.GetPlayers(numberOfRecords));
            data.AllGames = new Lazy<List<Game>>(() => MockData.GetGames(numberOfRecords));
            data.AllGameData = new Lazy<List<GameData>>(() => MockData.GetGameData(numberOfRecords));
            return data;
        }
    }

    public class MockData
    {
        public static List<Player> GetPlayers(int size)
        {
            List<Player> players = new List<Player>()
            {
                new Player()
                {
                    Id = 1, Name = "Nic", Wins = 5, GamesPlayed = 8, WinRate = 62.5, CumulativeSouls = 16,
                    AverageSouls = 2,
                },
                new Player()
                {
                    Id = 2, Name = "Clayton", Wins = 2, GamesPlayed = 10, WinRate = 20, CumulativeSouls = 8,
                    AverageSouls = 0.8,
                },
                new Player()
                {
                    Id = 3, Name = "Nico", Wins = 5, GamesPlayed = 10, WinRate = 50, CumulativeSouls = 6,
                    AverageSouls = 0.6,
                },
            };
            return players;
        }

        public static List<Game> GetGames(int size)
        {
            var games = new List<Game>()
            {
                new Game() { GameId = 1, NumberOfPlayers = 2,},
                new Game() { GameId = 2, NumberOfPlayers = 2,},
                new Game() { GameId = 3, NumberOfPlayers = 3,},
                new Game() { GameId = 4, NumberOfPlayers = 3,},
                new Game() { GameId = 5, NumberOfPlayers = 2,},
                new Game() { GameId = 6, NumberOfPlayers = 2,},
                new Game() { GameId = 7, NumberOfPlayers = 2,},
                new Game() { GameId = 8, NumberOfPlayers = 2,},
                new Game() { GameId = 9, NumberOfPlayers = 2,},
                new Game() { GameId = 10, NumberOfPlayers = 2,},
                new Game() { GameId = 11, NumberOfPlayers = 3,},
                new Game() { GameId = 12, NumberOfPlayers = 3,},
            };
            return games;
        }

        public static List<Character> GetCharacters(int size)
        {
            List<Character> characters = new List<Character>()
            {
                new Character()
                {
                    Id = 3, Name = "Maggy", Wins = 0, GamesPlayed = 1, WinRate = 0, CumulativeSouls = 4,
                    AverageSouls = 4,
                },
                new Character()
                {
                    Id = 4, Name = "Judas", Wins = 1, GamesPlayed = 3, WinRate = 33.33, CumulativeSouls = 11,
                    AverageSouls = 3.67,
                },
                new Character()
                {
                    Id = 5, Name = "Samson", Wins = 1, GamesPlayed = 1, WinRate = 100, CumulativeSouls = 4,
                    AverageSouls = 4,
                },
                new Character()
                {
                    Id = 6, Name = "Eve", Wins = 3, GamesPlayed = 3, WinRate = 100, CumulativeSouls = 8,
                    AverageSouls = 2.67,
                },
                new Character()
                {
                    Id = 7, Name = "Lilith", Wins = 1, GamesPlayed = 1, WinRate = 100, CumulativeSouls = 0,
                    AverageSouls = 0,
                },
                new Character()
                {
                    Id = 8, Name = "Blue Baby", Wins = 0, GamesPlayed = 1, WinRate = 0, CumulativeSouls = 4,
                    AverageSouls = 4,
                },
                new Character()
                {
                    Id = 9, Name = "Lazarus", Wins = 1, GamesPlayed = 5, WinRate = 20, CumulativeSouls = 6,
                    AverageSouls = 1.2,
                },
                new Character()
                {
                    Id = 10, Name = "The Forgotten", Wins = 0, GamesPlayed = 1, WinRate = 0, CumulativeSouls = 0,
                    AverageSouls = 0,
                },
                new Character()
                {
                    Id = 11, Name = "Eden", Wins = 2, GamesPlayed = 3, WinRate = 66.67, CumulativeSouls = 6,
                    AverageSouls = 2,
                },
                new Character()
                {
                    Id = 13, Name = "The Keeper", Wins = 2, GamesPlayed = 5, WinRate = 40, CumulativeSouls = 12,
                    AverageSouls = 2.4,
                },
                new Character()
                {
                    Id = 14, Name = "Azazel", Wins = 0, GamesPlayed = 2, WinRate = 0, CumulativeSouls = 0,
                    AverageSouls = 0,
                },
                new Character()
                {
                    Id = 19, Name = "Dark Judas", Wins = 1, GamesPlayed = 2, WinRate = 50, CumulativeSouls = 7,
                    AverageSouls = 3.5,
                },

            };
            return characters;
        }

        public static List<GameData> GetGameData(int size)
        {
            var gameDatum = new List<GameData>()
            {
                new GameData() { GameId = 1, PlayerId = 1, CharacterId = 13, Souls = 4, Win = 1, },
                new GameData() { GameId = 1, PlayerId = 2, CharacterId = 4, Souls = 1, Win = 0, },
                new GameData() { GameId = 2, PlayerId = 1, CharacterId = 7, Souls = 4, Win = 1, },
                new GameData() { GameId = 2, PlayerId = 2, CharacterId = 19, Souls = 3, Win = 0, },
                new GameData() { GameId = 3, PlayerId = 1, CharacterId = 8, Souls = 3, Win = 0, },
                new GameData() { GameId = 3, PlayerId = 2, CharacterId = 19, Souls = 4, Win = 1, },
                new GameData() { GameId = 3, PlayerId = 3, CharacterId = 13, Souls = 1, Win = 0, },
                new GameData() { GameId = 4, PlayerId = 1, CharacterId = 5, Souls = 4, Win = 1, },
                new GameData() { GameId = 4, PlayerId = 2, CharacterId = 9, Souls = 0, Win = 0, },
                new GameData() { GameId = 4, PlayerId = 3, CharacterId = 11, Souls = 1, Win = 0, },
                new GameData() { GameId = 5, PlayerId = 1, CharacterId = 9, Souls = 1, Win = 0, },
                new GameData() { GameId = 5, PlayerId = 3, CharacterId = 6, Souls = 4, Win = 1, },
                new GameData() { GameId = 6, PlayerId = 1, CharacterId = 6, Souls = 4, Win = 1, },
                new GameData() { GameId = 6, PlayerId = 3, CharacterId = 13, Souls = 3, Win = 0, },
                new GameData() { GameId = 7, PlayerId = 2, CharacterId = 4, Souls = 2, Win = 0, },
                new GameData() { GameId = 7, PlayerId = 3, CharacterId = 11, Souls = 4, Win = 1, },
                new GameData() { GameId = 8, PlayerId = 2, CharacterId = 14, Souls = 2, Win = 0, },
                new GameData() { GameId = 8, PlayerId = 3, CharacterId = 11, Souls = 4, Win = 1, },
                new GameData() { GameId = 9, PlayerId = 2, CharacterId = 4, Souls = 4, Win = 1, },
                new GameData() { GameId = 9, PlayerId = 3, CharacterId = 10, Souls = 1, Win = 0, },
                new GameData() { GameId = 10, PlayerId = 2, CharacterId = 9, Souls = 3, Win = 0, },
                new GameData() { GameId = 10, PlayerId = 3, CharacterId = 6, Souls = 4, Win = 1, },
                new GameData() { GameId = 11, PlayerId = 1, CharacterId = 9, Souls = 2, Win = 0, },
                new GameData() { GameId = 11, PlayerId = 2, CharacterId = 3, Souls = 3, Win = 0, },
                new GameData() { GameId = 11, PlayerId = 3, CharacterId = 13, Souls = 4, Win = 1, },
                new GameData() { GameId = 12, PlayerId = 1, CharacterId = 9, Souls = 4, Win = 1, },
                new GameData() { GameId = 12, PlayerId = 2, CharacterId = 14, Souls = 2, Win = 0, },
                new GameData() { GameId = 12, PlayerId = 3, CharacterId = 13, Souls = 1, Win = 0, },

            };
            return gameDatum;
        }
    }
}
