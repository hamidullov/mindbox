using System;
using System.Linq;
using Mindbox.Tools.Shapes;
using NUnit.Framework;

namespace Mindbox.Tools.Tests
{
    public class TriangleTest
    {
        [TestCase(6, 7, 8)]
        [TestCase(17, 15, 8)]
        [TestCase(8, 6, 4)]
        [TestCase(2, 2, 2)]
        [TestCase(4, 5, 3)]
        [TestCase(1.052, 1.053, 1.054)]
        public void CheckSidesFilling(double l1, double l2, double l3)
        {
            // arrange
            var maxL = new[] {l1, l2, l3}.Max();
            var t = new Triangle(l1, l2, l3);
            //act 

            // assert
            Assert.AreEqual(maxL, t.C);
        }

        [TestCase(3, 5, 4)]
       
        public void CheckOrthogonalityIsTrue(double l1, double l2, double l3)
        {
            // arrange
            var t = new Triangle(l1, l2, l3);
            //act 

            // assert
            Assert.IsTrue(t.IsOrthogonal);
        }

        [TestCase(8, 6, 4)]
        public void CheckOrthogonalityIsFalse(double l1, double l2, double l3)
        {
            // arrange
            var t = new Triangle(l1, l2, l3);
            //act 

            // assert
            Assert.IsFalse(t.IsOrthogonal);
        }

        [TestCase(3, 5, 4)]
        public void CheckOrthogonalSquare(double l1, double l2, double l3)
        {
            // arrange
            var t = new Triangle(l1, l2, l3);
            var sides = new[] {l1, l2, l3};
            var maxSide = sides.Max();
            var cathetus = sides.Where(r => r != maxSide).ToArray();
            var s = (cathetus[0] * cathetus[1]) / 2;
            
            //act 

            var square = t.Square;

            // assert
            Assert.IsTrue(square == s);
        }

        [Test]
        public void CheckSquare()
        {
            // arrange
            var t = new Triangle(6.87, 7.56, 10.57);
            double s = 25.903076;

            //act 

            var square = t.Square;

            // assert
            Assert.IsTrue(Math.Abs(square - s) < 0.000001);
        }

        [Test]
        public void CheckExpectingArgumentInvalid()
        {
            // arrange
            TestDelegate t = () => new Triangle(3, 5, 1);

            //act 

            // assert
            Assert.Catch<ArgumentException>(t);
        }
    }
}