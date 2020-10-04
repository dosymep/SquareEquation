namespace SquareEquation {
    public class Answer {
        public double X1 { get; set; }
        public double X2 { get; set; }

        public override string ToString() {
            return $"Equation answer is X1 = {X1:F4}; X2 = {X2:F4}";
        }
    }
}
