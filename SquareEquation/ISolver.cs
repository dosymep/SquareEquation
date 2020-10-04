using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareEquation {
    interface ISolver {
        double A { get; }
        double B { get; }
        double C { get; }

        Answer Solve();
    }
}
