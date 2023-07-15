using FourSoulsDataConnection.DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.DataHandling
{
    [TestFixture]
    public class figureShitOut
    {


        [Test]
        public void Test1()
        {
            FourSoulsData data = new FourSoulsDataDirectClient(true).Data;

            Thread t = new Thread(() =>
            {
                try
                {
                    var games = data.AllGameData.Value;
                }
                catch (Exception e)
                {

                }
                finally
                {

                }
                
            });

            t.Start();


            
        }
    }
}
