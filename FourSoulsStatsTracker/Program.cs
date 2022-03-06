using System;
using System.Collections.Generic;

namespace FourSoulsStatsTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine.LoadAllData();
            int breakpoint = 0;
            Engine.SaveAllData();
        }
    }
}
