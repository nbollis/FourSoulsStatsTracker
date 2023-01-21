namespace FourSouls
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int GamesPlayed { get; set; }
        public double WinRate => Wins / (double)GamesPlayed;

    }

    public class Character
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int GamesPlayed { get; set; }
        public double WinRate => Wins / (double)GamesPlayed;
    }

    public class Game
    {
        public int GameID { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan LengthOfGame { get; set; }
        public int NumberOfPlayers { get; set; }
    }

    public class GameData
    {
        public int GameID { get; set; }
        public int PlayerId { get; set; }
        public int CharacterId { get; set; }
        public int Souls { get; set; }
        public bool Win { get; set; }
    }
}