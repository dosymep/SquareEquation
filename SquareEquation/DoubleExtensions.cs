using System;

namespace SquareEquation {
    internal static class DoubleExtensions {
        public static bool EqualsEps(this double source, double value, double epsilon = 0.001) {
            return Math.Abs(source - value) < epsilon;
        }
    }
}

