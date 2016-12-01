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
        public void LinearEquationSimpleTest()
        {
            LinearEquation eqn = new LinearEquation("3x+4y=10");
            Assert.AreEqual(3, eqn["x"]);
            Assert.AreEqual(4, eqn["y"]);
            Assert.AreEqual(10, eqn["equals"]);
            
        }

        [TestMethod()]
        public void LinearEquationNegativeValueTest()
        {
            LinearEquation eqn = new LinearEquation("-3x+4y=10");
            Assert.AreEqual(-3, eqn["x"]);
            Assert.AreEqual(4, eqn["y"]);
            Assert.AreEqual(10, eqn["equals"]);
        }

        [TestMethod()]
        public void LinearEquationVariableLengthTest()
        {
            LinearEquation eqn = new LinearEquation("-3xy+4yz=10");
            Assert.AreEqual(-3, eqn["xy"]);
            Assert.AreEqual(4, eqn["yz"]);
            Assert.AreEqual(10, eqn["equals"]);
        }

        [TestMethod()]
        public void LinearEquationNegativeEqualsTest()
        {
            LinearEquation eqn = new LinearEquation("-3xy+4yz=-10");
            Assert.AreEqual(-3, eqn["xy"]);
            Assert.AreEqual(4, eqn["yz"]);
            Assert.AreEqual(-10, eqn["equals"]);
        }

        [TestMethod()]
        public void LinearEquationFloatingPointTest()
        {
            LinearEquation eqn = new LinearEquation("-3.25xy+0.54yz=-10.5");
            Assert.AreEqual(-3.25, eqn["xy"]);
            Assert.AreEqual(0.54f, eqn["yz"]);
            Assert.AreEqual(-10.5, eqn["equals"]);
        }
    }
}