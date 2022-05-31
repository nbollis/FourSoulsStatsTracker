using System;
using System.Collections.Generic;

namespace FourSoulsStatsTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            Engine.LoadAllData();
            int breakpoint = 0;
            Engine.SaveAllData();
        }
    }
}
