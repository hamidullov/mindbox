using System;
using System.Collections.Generic;
using System.Text;
using Mindbox.Tools.Abstract;

namespace Mindbox.Tools.Shapes
{
    public class Triangle : IShape
    {
        private double? _square;
        private bool? _isOrthogonal;

        public Triangle(double l1, double l2, double l3)
        {
            ValidateSides(l1, l2, l3);
            FillSides(l1, l2, l3);
        }

        private void ValidateSides(double l1, double l2, double l3)
        {
            if (l1 + l2 <= l3 || l1 + l3 <= l2 ||
                l2 + l3 <= l1)
                throw new ArgumentException("Invalid triangle sides length");
        }

        private void FillSides(double l1, double l2, double l3)
        {
            if (l1 < l2)
            {
                A = l1;
                if (l2 < l3)
                {
                    B = l2;
                    C = l3;
                }
                else
                {
                    B = l3;
                    C = l2;
                }
            }
            else
            {
                A = l2;
                if (l1 < l3)
                {
                    B = l1;
                    C = l3;
                }
                else
                {
                    B = l3;
                    C = l1;
                }
            }
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double Square => (_square ?? (_square = CalcSquare())).Value;

        private double CalcSquare()
        {
            if (IsOrthogonal)
            {
                return A * B / 2;
            }

            var p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }


        public bool IsOrthogonal
        {
            get
            {
                if (_isOrthogonal == null)
                {
                    _isOrthogonal = Math.Abs(C * C - (A * A + B * B)) < 0.000001;
                }

                return _isOrthogonal.Value;
            }
        }
        public override string ToString()
        {
            return $"Triangle with A: {A},\tB: {B},\tC: {C}";
        }

    }
}
