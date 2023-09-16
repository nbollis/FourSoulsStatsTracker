using FourSoulsDataConnection;

namespace Graphing
{
    public class WinRateHeatMap
    {
        internal record PlayerData(string PlayerName1, string PlayerName2, double WinRate1v2);



        
        public WinRateHeatMap(List<ICharPlayer> list, ref List<Game> filteredGames)
        {
            GeneratePlot(list, filteredGames);
        }

        public void GeneratePlot(List<ICharPlayer> list, List<Game> gamesToParse)
        {
            double[][] z = new double[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                ICharPlayer outerItem = list[i];
                z[i] = new double[list.Count];

                var test = outerItem.GameDatas.ToList() ;

                for (int j = 0; j < list.Count; j++)
                {
                    ICharPlayer innerItem = list[j];

                    double winRate;
                    if (innerItem.Equals(outerItem))
                        winRate = 0;
                    else
                    {




                        winRate = i;
                    }


                    z[i][j] = winRate;
                }
            }





            //var temp = Chart.Heatmap<double, string, string, string>
            //    (
            //       X, 
            //    );
        }
    }
}