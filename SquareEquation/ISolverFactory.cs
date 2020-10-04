using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareEquation {
    public interface ISolverFactory {
        ISolver CreateSolverFromConsole();

        ISolver[] CreateSolverFromFile();
        ISolver[] CreateSolverFromFile(string filePath);

        ISolver CreateSolver(string @params);
    }
}
