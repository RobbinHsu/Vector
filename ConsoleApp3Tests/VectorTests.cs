using NUnit.Framework;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Tests
{
    [TestFixture()]
    public class VectorTests
    {
        private List<double> _a;
        private List<double> _b;
        private double[] _bTemp;
        private Vector _va;
        private Vector _vb;

        [SetUp]
        public void Setup()
        {
            _a = new List<double>();
            _a.Add(1);
            _a.Add(3);
            _a.Add(5);

            _bTemp = new double[] {2, 4, 6};
            _b = new List<double>(_bTemp);

            _va = new Vector(_a);
            _vb = new Vector(_b);
        }

        [Test()]
        public void add_test_v1()
        {
            var actual = _va.add(_vb).ToString();
            var expected = "(3,7,11)";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void dimension_test_v1()
        {
            var actual = _va.Dimension;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void dimension_test_v2()
        {
            var actual = _vb.Dimension;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void scalarMultiplication_test_v1()
        {
            var actual = _vb.scalarMultiplication(3.00).ToString();
            var expected = "(6,12,18)";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void subtract_test_v1()
        {
            var actual = _vb.subtract(_va).ToString();
            var expected = "(1,1,1)";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void vectors_expression_test_v1()
        {
            var actual = _va.ToString();
            var expected = "(1,3,5)";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void vectors_expression_test_v2()
        {
            var actual = _vb.ToString();
            var expected = "(2,4,6)";
            Assert.AreEqual(expected, actual);
        }
    }
}