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

        private double _a, _b, _c;

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
                _a = l1;
                if (l2 < l3)
                {
                    _b = l2;
                    _c = l3;
                }
                else
                {
                    _b = l3;
                    _c = l2;
                }
            }
            else
            {
                _a = l2;
                if (l1 < l3)
                {
                    _b = l1;
                    _c = l3;
                }
                else
                {
                    _b = l3;
                    _c = l1;
                }
            }
        }

        public double A => _a;
        public double B => _b;
        public double C => _c;
        public double Square => (_square ?? (_square = CalcSquare())).Value;

        private double CalcSquare()
        {
            if (IsOrthogonal)
            {
                return _a * _b / 2;
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
                    _isOrthogonal = Math.Abs(_c * _c - (_a * _a + _b * _b)) < 0.000001;
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
