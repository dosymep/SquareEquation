using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareEquation {
    interface ISolverFactory {
        ISolver CreateSolverFromConsole();

        ISolver[] CreateSolverFromFile();
        ISolver[] CreateSolverFromFile(string filePath);

        ISolver CreateSolver(string @params);
    }
}
