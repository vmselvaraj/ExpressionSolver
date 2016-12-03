using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beyond.ExpressionSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.ExpressionSolver.Tests
{
    [TestClass()]
    public class NumericExpressionTests
    {
        [TestMethod()]
        public void SimpleExpressions()
        {
            Assert.AreEqual(1, NumericExpression.Solve("1/1"));
            Assert.AreEqual(0.5d, NumericExpression.Solve("1/2"));
            Assert.AreEqual(1, NumericExpression.Solve("1*1"));
            Assert.AreEqual(2, NumericExpression.Solve("1+1"));
            Assert.AreEqual(0, NumericExpression.Solve("1-1"));
            Assert.AreEqual(0, NumericExpression.Solve("-1+1"));
            Assert.AreEqual(1, NumericExpression.Solve("1^1"));
            Assert.AreEqual(1, NumericExpression.Solve("-1^2"));
            Assert.AreEqual(3, NumericExpression.Solve("-1+2*2"));
            Assert.AreEqual(-3, NumericExpression.Solve("-2*2+1"));
            Assert.AreEqual(49, NumericExpression.Solve("(3 + 4)^2"));
            Assert.AreEqual(0.25d, NumericExpression.Solve("2^-2"));
            Assert.AreEqual(0.25d, NumericExpression.Solve("1/(2^2)"));
            Assert.AreEqual(4.25d, NumericExpression.Solve("1/4+2*2"));
            Assert.AreEqual(0.25d, NumericExpression.Solve("1/4+2*2-2^2(2/2)"));
            Assert.AreEqual(1, NumericExpression.Solve("-1 * -1"));
            Assert.AreEqual(16, NumericExpression.Solve("(2^2)2^2"));
            Assert.AreEqual(0, NumericExpression.Solve("1^0"));
        }


        [TestMethod()]
        public void FloatingPoint()
        {
            Assert.AreEqual(0.01d, NumericExpression.Solve("0.1^2"));
            Assert.AreEqual(2, NumericExpression.Solve("4^0.5"));
            Assert.AreEqual(0.12d, NumericExpression.Solve("0.1 + 0.2 * 0.1"));
            Assert.AreEqual(0.001d, NumericExpression.Solve("-0.1 * -0.1"));
            Assert.AreEqual(10, NumericExpression.Solve("1/0.1"));
            Assert.AreEqual(0.1d, NumericExpression.Solve("-0.1 + 0.2 * 0.01/0.1^2"));

        }
    }
}