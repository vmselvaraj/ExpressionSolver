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
            Assert.AreEqual(1, NumericExpression.Evaluate("1/1"));
            Assert.AreEqual(0.5d, NumericExpression.Evaluate("1/2"));
            Assert.AreEqual(1, NumericExpression.Evaluate("1*1"));
            Assert.AreEqual(2, NumericExpression.Evaluate("1+1"));
            Assert.AreEqual(0, NumericExpression.Evaluate("1-1"));
            Assert.AreEqual(0, NumericExpression.Evaluate("-1+1"));
            Assert.AreEqual(1, NumericExpression.Evaluate("1^1"));
            Assert.AreEqual(1, NumericExpression.Evaluate("-1^2"));
            Assert.AreEqual(3, NumericExpression.Evaluate("-1+2*2"));
            Assert.AreEqual(-3, NumericExpression.Evaluate("-2*2+1"));
            Assert.AreEqual(49, NumericExpression.Evaluate("(3 + 4)^2"));
            Assert.AreEqual(0.25d, NumericExpression.Evaluate("2^-2"));
            Assert.AreEqual(0.25d, NumericExpression.Evaluate("1/(2^2)"));
            Assert.AreEqual(4.25d, NumericExpression.Evaluate("1/4+2*2"));
            Assert.AreEqual(0.25d, NumericExpression.Evaluate("1/4+2*2-2^2(2/2)"));
            Assert.AreEqual(1, NumericExpression.Evaluate("-1 * -1"));
            Assert.AreEqual(16, NumericExpression.Evaluate("(2^2)2^2"));
            Assert.AreEqual(0, NumericExpression.Evaluate("1^0"));
        }


        [TestMethod()]
        public void FloatingPoint()
        {
            Assert.AreEqual(0.01d, NumericExpression.Evaluate("0.1^2"));
            Assert.AreEqual(2, NumericExpression.Evaluate("4^0.5"));
            Assert.AreEqual(0.12d, NumericExpression.Evaluate("0.1 + 0.2 * 0.1"));
            Assert.AreEqual(0.001d, NumericExpression.Evaluate("-0.1 * -0.1"));
            Assert.AreEqual(10, NumericExpression.Evaluate("1/0.1"));
            Assert.AreEqual(0.1d, NumericExpression.Evaluate("-0.1 + 0.2 * 0.01/0.1^2"));

        }
    }
}