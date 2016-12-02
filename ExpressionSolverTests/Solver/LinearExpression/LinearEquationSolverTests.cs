using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beyond.ExpressionSolver.Solver.LinearExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.ExpressionSolver.Solver.LinearExpression.Tests
{
    [TestClass()]
    public class LinearEquationSolverTests
    {
        [TestMethod()]
        public void LinearEquationSolverTest()
        {
            LinearEquationSolver solver = new LinearEquationSolver();
            solver.AddEquation("3x+2y-z=1");
            solver.AddEquation("2x-2y+4z=-2");
            solver.AddEquation("-x+0.5y-z=0");
            solver.Solve();
        }
    }
}