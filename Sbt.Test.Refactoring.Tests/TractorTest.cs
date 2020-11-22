using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class TractorTest
    {
        [TestMethod]
        public void TestShouldMoveForward()
        {
            Tractor tractor = new Tractor();
            
            tractor.Move("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(1, tractor.GetPositionY());
        }

        [TestMethod]
        public void TestShouldTurn()
        {
            Tractor tractor = new Tractor();
            
            tractor.Move("T");
            Assert.AreEqual(Orientation.East, tractor.Orientation);

            tractor.Move("T");
            Assert.AreEqual(Orientation.South, tractor.Orientation);

            tractor.Move("T");
            Assert.AreEqual(Orientation.West, tractor.Orientation);

            tractor.Move("T");
            Assert.AreEqual(Orientation.North, tractor.Orientation);
        }

        [TestMethod]
        public void TestShouldTurnAndMoveInTheRightDirection()
        {
            Tractor tractor = new Tractor();

            tractor.Move("T");
            tractor.Move("F");
            Assert.AreEqual(1, tractor.GetPositionX());
            Assert.AreEqual(0, tractor.GetPositionY());

            tractor.Move("T");
            tractor.Move("F");
            Assert.AreEqual(1, tractor.GetPositionX());
            Assert.AreEqual(-1, tractor.GetPositionY());

            tractor.Move("T");
            tractor.Move("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(-1, tractor.GetPositionY());

            tractor.Move("T");
            tractor.Move("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(0, tractor.GetPositionY());
        }

        [TestMethod]
        public void TestShouldThrowExceptionIfFallsOffPlateau()
        {
            Tractor tractor = new Tractor();

            tractor.Move("F");
            tractor.Move("F");
            tractor.Move("F");
            tractor.Move("F");
            tractor.Move("F");

            try
            {
                tractor.Move("F");
                Assert.Fail("Tractor was expected to fall off the plateau");
            }
            catch (TractorInDitchException ex)
            {
            }
        }
    }
}
