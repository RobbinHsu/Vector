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
        private List<double> _c;
        private double[] _cTemp;
        private Vector _va;
        private Vector _vb;
        private Vector _vf;

        [SetUp]
        public void Setup()
        {
            _a = new List<double> {1, 3, 5};

            _bTemp = new double[] {2, 4, 6};
            _b = new List<double>(_bTemp);

            _va = new Vector(_a);
            _vb = new Vector(_b);

            _cTemp = new double[] {3, 3};
            _c = new List<double>(_cTemp);
            _vf = new Vector(_c);
        }

        [Test()]
        public void dotProduct_test()
        {
            var actual = _va.dotProduct(_vb);
            var expected = 44;
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
        public void three_dimension_test()
        {
            var actual = _va.Dimension;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void three_vector_add_success_test()
        {
            var actual = _va.add(_vb).ToString();
            var expected = "(3,7,11)";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void three_vector_add_two_vector_failed_test()
        {
            var expectedException = new Exception();
            try
            {
                var actual = _va.add(_vf).ToString();
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [Test()]
        public void three_vectors_toString_test()
        {
            var actual = _vf.ToString();
            var expected = "(3,3)";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void two_dimension_test()
        {
            var actual = _vf.Dimension;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void two_vectors_toString_test()
        {
            var actual = _va.ToString();
            var expected = "(1,3,5)";
            Assert.AreEqual(expected, actual);
        }
    }
}