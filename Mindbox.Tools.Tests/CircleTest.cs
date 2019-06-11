using System;
using System.Collections.Generic;
using System.Text;
using Mindbox.Tools.Shapes;
using NUnit.Framework;

namespace Mindbox.Tools.Tests
{
    public class CircleTest
    {
        [TestCase(5)]
        [TestCase(5.657)]
        [TestCase(2)]
        public void CheckSquare(double r)
        {
            // arrange
            var c = new Circle(r);
            double s = Math.PI * r * r;

            //act 

            var square = c.Square;

            // assert
            Assert.AreEqual(square,s);
        }
    }
}
