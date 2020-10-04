using System;
using System.Collections;
using NUnit.Framework;
using SquareEquation;

namespace SquareEquationUnitTest {
    [TestFixture]
    public class SquareEquationSolverUnitTest {
        private ISolverFactory _solverFactory;

        [SetUp]
        public void SetUp() {
            _solverFactory = SquareEquationFactory.CreateSolverFactory();
        }

        [TestCaseSource(nameof(TestCases))]
        public Answer SolveTestMethod(string @params) {
            ISolver solver = _solverFactory.CreateSolver(@params);
            return solver.Solve();
        }

        public static IEnumerable TestCases {
            get {
                yield return new TestCaseData("2 5 -3.5").Returns(new Answer() { X1 = 0.5700, X2 = -3.0700 });
                yield return new TestCaseData("1 4 1").Returns(new Answer() { X1 = -0.2679, X2 = -3.7321 });
            }
        }
    }
}
