using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSoulsStatsTracker
{
    class Character
    {
        protected int wins;
        protected int losses;
        protected double winRate;
        protected double averageSouls;
        protected List<Game> allGames;
        protected string characterName;

        public void postgameCalculations()
        {
            this.calculateWinRate();
            this.calculateAverageSouls();
        }
        private void calculateWinRate()
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

        private void calculateAverageSouls()
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

        public void addWinLoss(Game game)
        {

        }
    }
}
