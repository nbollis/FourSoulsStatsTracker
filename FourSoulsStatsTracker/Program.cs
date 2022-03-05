using System;
using System.Collections.Generic;

namespace FourSoulsStatsTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine.LoadAllData();
            Engine.SaveAllData();
        }
    }
}
