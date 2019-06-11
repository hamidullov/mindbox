using System;
using System.Collections.Generic;
using System.Text;
using Mindbox.Tools.Abstract;

namespace Mindbox.Tools.Shapes
{
    public class Circle : IShape
    {
        private double? _square;

        public Circle(double r)
        {
            R = r;
        }

        public double R { get; }


        public double Square => (_square ?? (_square = Math.PI * R * R)).Value;

        public override string ToString()
        {
            return $"Circle with radius: {R}";
        }
    }
}
