using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareEquation {
    internal class SquareEquationFactory : ISolverFactory {
        private readonly CultureInfo _cultureInfo;

        private SquareEquationFactory() {
            _cultureInfo = CultureInfo.InvariantCulture;
        }

        private SquareEquationFactory(CultureInfo cultureInfo) {
            _cultureInfo = cultureInfo;
        }

        public static ISolverFactory CreateSolverFactory() {
            return new SquareEquationFactory();
        }

        public static ISolverFactory CreateSolverFactory(CultureInfo cultureInfo) {
            return new SquareEquationFactory(cultureInfo);
        }

        public ISolver CreateSolverFromConsole() {
            Console.WriteLine("Please input a coefficents: ");
            return CreateSolver(Console.ReadLine());
        }

        public ISolver[] CreateSolverFromFile() {
            Console.WriteLine("Please input a file path: ");
            return CreateSolverFromFile(Console.ReadLine());
        }

        public ISolver[] CreateSolverFromFile(string filePath) {
            if(string.IsNullOrEmpty(filePath)) {
                throw new ArgumentException("FilePath cannont be null or empty.", nameof(filePath));
            }

            return File.ReadAllLines(filePath)
                .Select(item => CreateSolver(item))
                .ToArray();
        }

        public ISolver CreateSolver(string @params) {
            if(string.IsNullOrEmpty(@params)) {
                throw new ArgumentException("Coefficent cannont be null or empty.", nameof(@params));
            }

            string[] abc = @params.Split(' ');
            if(abc.Length != 3) {
                throw new ArgumentException("Coefficent equation arern't correct.");
            }

            double a = double.Parse(abc[0], _cultureInfo);
            double b = double.Parse(abc[1], _cultureInfo);
            double c = double.Parse(abc[2], _cultureInfo);

            return new SquareEquationSolver() { A = a, B = b, C = c };
        }
    }
}
