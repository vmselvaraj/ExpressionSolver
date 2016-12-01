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
    public class LinearEquationTests
    {
        [TestMethod()]
        public void LinearEquationTest()
        {
            LinearEquation eqn = new LinearEquation("3x+4y=10");
            Assert.AreEqual(3, eqn["x"]);
            Assert.AreEqual(4, eqn["y"]);
            Assert.AreEqual(10, eqn["equals"]);
            
        }
    }
}