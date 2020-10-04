using System;

namespace SquareEquation {
    public class Answer {
        public double X1 { get; set; }
        public double X2 { get; set; }



        public override string ToString() {
            return $"Equation answer is X1 = {X1:F4}; X2 = {X2:F4}";
        }

        public override int GetHashCode() {
            var hashCode = 1001978625;
            hashCode = hashCode * -1521134295 + X1.GetHashCode();
            hashCode = hashCode * -1521134295 + X2.GetHashCode();

            return hashCode;
        }

        public override bool Equals(object obj) {
            if(obj is Answer answer) {
                return Equals(answer);
            }

            return false;
        }

        public bool Equals(Answer other) {
            if(other == null) {
                return false;
            }

            return X1.EqualsEps(other.X1) && X2.EqualsEps(other.X2);
        }
    }
}
