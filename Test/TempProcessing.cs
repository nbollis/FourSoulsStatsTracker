using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourSoulsDataConnection;
using FourSoulsDataConnection.DataBase;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    internal class TempProcessing
    {

        [Test]
        public void GenerateHexCodeQuery1()
        {
            FourSoulsData data = new FourSoulsDataDirectClient(true).Data;
            var playerNames = DataOperations.GetAllPlayerNames(data);
            var characterNames = DataOperations.GetAllCharacterNames(data);
            var sb = new StringBuilder();

            
            var colorQueue = new Queue<string>(File.ReadAllLines(
                    @"C:\Users\nboll\source\repos\FourSoulsStatsTracker\FourSoulsDataConnection\Resources\Colors\TwentyColors.txt")
                .ToArray());
            sb.AppendLine("USE FourSoulsStats;");
            foreach (var player in playerNames)
            {
                sb.AppendLine("Update Players");
                sb.AppendLine($"Set ColorCode = '{colorQueue.Dequeue()}' Where PlayerName = '{player}'");
            }
            sb.AppendLine("GO");
            var playerScript = sb.ToString();
            sb.Clear();


            var characterColorQueue = new Queue<string>(File.ReadAllLines(
                    @"C:\Users\nboll\source\repos\FourSoulsStatsTracker\FourSoulsDataConnection\Resources\Colors\SixtyColors.txt")
                .ToArray());
                
            sb.AppendLine("USE FourSoulsStats;");
            foreach (var character in characterNames)
            {
                sb.AppendLine("Update Characters");
                sb.AppendLine($"Set ColorCode = '{characterColorQueue.Dequeue()}' Where CharacterName = '{character}'");
            }
            sb.AppendLine("GO");
            var characterScript = sb.ToString();
            sb.Clear();


        }
    }
}
