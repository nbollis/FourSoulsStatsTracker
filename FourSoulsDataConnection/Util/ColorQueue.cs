using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection.DataBase;

namespace FourSoulsDataConnection.Util
{
    internal class ColorQueue
    {
        private static Queue<string> _playerQueue;
        private static Queue<string> _characterQueue;


        internal static Queue<string> PlayerQueue => _playerQueue;
        internal static Queue<string> CharacterQueue => _characterQueue;

        static ColorQueue()
        {
            var playerColors =
                File.ReadAllLines(
                    @"C:\Users\nboll\source\repos\FourSoulsStatsTracker\FourSoulsDataConnection\Resources\Colors\TwentyColors.txt");
            var characterColors =
                File.ReadAllLines(
                    @"C:\Users\nboll\source\repos\FourSoulsStatsTracker\FourSoulsDataConnection\Resources\Colors\SixtyColors.txt");

            _playerQueue = new Queue<string>(playerColors);
            _characterQueue = new Queue<string>(characterColors);
        }

        internal static string GetNextColor(FourSoulsData data, ICharPlayer charPlayer)
        {
            Queue<string> queue = charPlayer is Player ? PlayerQueue : CharacterQueue;

            var colors = data.AllPlayers.Value.Select(p => p.ColorCode).ToArray();
            while (colors.Contains(queue.Peek()))
            {
                queue.Dequeue();
            }

            return queue.Dequeue();
        }
    }
}
