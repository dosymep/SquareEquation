﻿using System;

namespace SquareEquation {
    internal class SquareEquationSolver : ISolver {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Answer Solve() {
            double discriminant = GetDiscriminant();
            if(discriminant < 0) {
                throw new DiscriminantLessZeroException("Equation doesn't have a variety.");
            }

            return new Answer() { X1 = GetX1(discriminant), X2 = GetX2(discriminant) };
        }

        private double GetDiscriminant() {
            return B * B - 4 * A * C;
        }

        private double GetX1(double discriminant) {
            return (-B + Math.Sqrt(discriminant)) / (2 * A);
        }

        private double GetX2(double discriminant) {
            return (-B - Math.Sqrt(discriminant)) / (2 * A);
        }

        public override string ToString() {
            return $"Equation coefficents: A = {A}; B = {B}; C = {C}. Equation discriminant: {GetDiscriminant()}";

        }
    }
}
