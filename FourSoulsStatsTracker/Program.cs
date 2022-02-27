using System;
using System.Collections.Generic;

namespace FourSoulsStatsTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Engine.LoadAllData();
            Engine.SaveAllData();
        }
    }
}
