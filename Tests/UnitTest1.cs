
using FourSoulsStatsTracker;
using System.IO;
using NUnit.Framework;
using System.Reflection;
using System;

namespace Tests
{
    [TestFixture]
    internal static class UnitTest1
    {
        // TODO: Implement unit tests

        [Test]
        public static void TestAllCharactersHaveImages()
        {
            string[] names = new string[Character.characterNames.Length];
            Character.characterNames.CopyTo(names, 0);

            string testpath = @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Images\Abe.png";
            var image = File.Open(testpath, FileMode.Open);

            foreach (var name in Character.characterNames)
            {

            }
        }

        [Test]
        public static void TestGetFolderPath()
        {
            string storage = "Storage";
            string images = "Images";
            string storagepath = FourSoulsGame.GetFolderPath(storage);
            string imagespath = FourSoulsGame.GetFolderPath(images);

            Assert.AreEqual(imagespath, @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Images\");
            Assert.AreEqual(storagepath, @"C:\Users\nboll\Source\Repos\FourSoulsStatsTracker\FourSoulsStatsTracker\Storage\");
        }
    }
}
