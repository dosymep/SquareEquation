using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareEquation {
    public class Program {
        public static void Main(string[] args) {
            try {
                ISolverFactory factory = SquareEquationFactory.CreateSolverFactory();

                ISolver solver = factory.CreateSolver("2 5 -3.5");
                Answer answer = solver.Solve();

                Console.WriteLine(solver);
                Console.WriteLine(answer);
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
