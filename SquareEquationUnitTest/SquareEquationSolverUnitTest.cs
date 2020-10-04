using System;
using System.Collections;
using System.IO;
using NUnit.Framework;
using SquareEquation;

namespace SquareEquationUnitTest {
    [TestFixture]
    public class SquareEquationSolverUnitTest {
        private ISolverFactory _solverFactory;

        public static IEnumerable FileTestCases {
            get {
                yield return Path.Combine(TestContext.CurrentContext.TestDirectory, "SolveTests.txt");
            }
        }

        public static IEnumerable PositiveTestCases {
            get {
                yield return new TestCaseData("1 4 1").Returns(new Answer() { X1 = -0.2679, X2 = -3.7321 });
                yield return new TestCaseData("2 5 -3.5").Returns(new Answer() { X1 = 0.5700, X2 = -3.0700 });
            }
        }

        [SetUp]
        public void SetUp() {
            _solverFactory = SquareEquationFactory.CreateSolverFactory();
        }

        [TestCaseSource(nameof(PositiveTestCases))]
        public Answer SolveTestPositiveMethod(string @params) {
            ISolver solver = _solverFactory.CreateSolver(@params);
            return solver.Solve();
        }

        [TestCase("1 0 1")]
        [TestCase("1 1 1")]
        public void SolveTestFailMethod(string @params) {
            ISolver solver = _solverFactory.CreateSolver(@params);
            Assert.Throws<DiscriminantLessZeroException>(() => solver.Solve());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("1")]
        [TestCase("1 0 1 2")]
        public void SolveFactoryTestArgumentExceptionMethod(string @params) {
            Assert.Throws<ArgumentException>(() => _solverFactory.CreateSolver(@params));
        }

        [TestCase("1 0.9 1,2")]
        [TestCase("DDD YYY SSS")]
        public void SolveFactoryTestFormatExceptionMethod(string @params) {
            // Не понял, почему double.Parce("1,2", CultureInfo.InvariantCulture) 
            // не выбрасывает иселючение FormatException
            Assert.Throws<FormatException>(() => _solverFactory.CreateSolver(@params));
        }

        [TestCase("SolveTestNotExist.txt")]
        public void SolveTestFileFileNotFoundExceptionMethod(string filePath) {
            Assert.Throws<FileNotFoundException>(() => _solverFactory.CreateSolverFromFile(filePath));
        }

        [TestCaseSource(nameof(FileTestCases))]
        public void SolveTestFileMethod(string filePath) {
            // Не разобрался почему файл возвращается не с того пути
            ISolver[] solvers = _solverFactory.CreateSolverFromFile(filePath);
            Assert.AreEqual(solvers.Length, 4);
        }
    }
}
