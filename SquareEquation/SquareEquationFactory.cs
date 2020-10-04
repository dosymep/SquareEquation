using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareEquation {
    internal class SquareEquationFactory : ISolverFactory {
        public ISolver CreateSolver(string @params) {
            string[] abc = @params.Split(' ');
            if(abc.Length != 3) {
                throw new ArgumentException("Введены неверные параметры уравнения.");
            }

            double a = double.Parse(abc[0]);
            double b = double.Parse(abc[1]);
            double c = double.Parse(abc[2]);

            return new SquareEquationSolver() { A = a, B = b, C = c };
        }
    }
}
