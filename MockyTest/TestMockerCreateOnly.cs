using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using Mocky;
using Request;

namespace Mocky.Test
{
    [TestClass]
    public class TestMockerCreateOnly
    {
        readonly ICalculator calc;
        readonly IHttpRequest req;

        public TestMockerCreateOnly()
        {
            Mocker mockCalc = new Mocker(typeof(ICalculator));
            calc = (ICalculator)mockCalc.Create();
            Mocker mockReq = new Mocker(typeof(IHttpRequest));
            req = (IHttpRequest) mockReq.Create();
        }

        [TestMethod]
        public void TestCalculatorTypeName()
        {
            string klassName = calc.ToString(); // OK ToString() inherited from Object
            Assert.AreEqual("MockICalculator", klassName);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestCalculatorAddNotImplemented()
        {
            calc.Add(2, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestCalculatorSubNotImplemented()
        {
            calc.Sub(2, 3);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestCalculatorMulNotImplemented()
        {
            calc.Mul(2, 3);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestCalculatorDivNotImplemented()
        {
            calc.Div(2, 3);
        }

        [TestMethod]
        public void TestRequestTypeName()
        {
            string klassName = req.ToString(); // OK ToString() inherited from Object
            Assert.AreEqual("MockIHttpRequest", klassName);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestRequestGetBodyNotImplemented()
        {
            req.GetBody("");
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestRequestDisposeNotImplemented()
        {
            req.Dispose();
        }
    }
}
