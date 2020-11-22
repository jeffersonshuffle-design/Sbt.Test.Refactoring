using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbt.Test.Refactoring.Commands;
using Sbt.Test.Refactoring.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class GameUnitsTest
    {
  

        [TestMethod]
        public void GroupOfUnitsShouldExecuteCommand()
        {
            var map = new Map(5, 5);
            var collection = new UnitCollection() 
            {
                new Units.Tractor(map,Orientation.North,new System.Drawing.Point(0,0)),
                new Stoun(map,new System.Drawing.Point(1,0)),
                new Wind(map)
            };

            collection.ExecuteCommand(new MoveForwardCommand());
            Assert.AreEqual(1, (collection.ElementAt(0) as Units.Tractor).PositionY);
            Assert.AreEqual(0, (collection.ElementAt(1) as Units.Stoun).PositionY);

            collection.ExecuteCommand(new TurnClockwiseCommand());
            Assert.AreEqual(Orientation.East, (collection.ElementAt(0) as Units.Tractor).Orientation);
            Assert.AreEqual(Orientation.East, (collection.ElementAt(2) as Units.Wind).Orientation);

        }

     
    }
}
