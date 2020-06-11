using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Vector
    {
        public int Dimension;
        public List<double> Vectors;

        //method
        public Vector(List<double> vectors)
        {
            Vectors = vectors;
            Dimension = vectors.Count;
        }

        public Vector add(Vector outter)
        {
            if (outter.Vectors.Count != Vectors.Count)
            {
                throw new Exception();
            }

            var tempVector = new List<double>();
            var outterEnumerator = outter.Vectors.GetEnumerator();
            var sourceEnumerator = Vectors.GetEnumerator();
            while (outterEnumerator.MoveNext() && sourceEnumerator.MoveNext())
            {
                var outterVector = outterEnumerator.Current;
                var sourceVector = sourceEnumerator.Current;
                tempVector.Add(outterVector + sourceVector);
            }

            return new Vector(tempVector);
        }

        public Vector subtract(Vector outter)
        {
            if (outter.Vectors.Count != Vectors.Count)
            {
                throw new Exception();
            }

            var tempVector = new List<double>();
            var outterEnumerator = outter.Vectors.GetEnumerator();
            var sourceEnumerator = Vectors.GetEnumerator();
            while (outterEnumerator.MoveNext() && sourceEnumerator.MoveNext())
            {
                var outterVector = outterEnumerator.Current;
                var sourceVector = sourceEnumerator.Current;
                tempVector.Add(sourceVector - outterVector);
            }

            return new Vector(tempVector);
        }

        public Vector scalarMultiplication(double scalar)
        {
            var tempVector = new List<double>();
            var vectorsEnumerator = Vectors.GetEnumerator();
            while (vectorsEnumerator.MoveNext())
            {
                var vector = vectorsEnumerator.Current;
                tempVector.Add(vector * scalar);
            }

            return new Vector(tempVector);
        }

        public double dotProduct(Vector outter)
        {
            var outterEnumerator = outter.Vectors.GetEnumerator();
            var sourceEnumerator = Vectors.GetEnumerator();
            var sumVector = 0D;
            while (outterEnumerator.MoveNext() && sourceEnumerator.MoveNext())
            {
                var outterVector = outterEnumerator.Current;
                var sourceVector = sourceEnumerator.Current;
                sumVector += (outterVector * sourceVector);
            }

            return sumVector;
        }

        public override string ToString()
        {
            var vectorExpression = new StringBuilder();
            vectorExpression.Append("(");

            var vectorsEnumerator = Vectors.GetEnumerator();
            var moveNext = vectorsEnumerator.MoveNext();
            while (moveNext)
            {
                var vector = vectorsEnumerator.Current;
                vectorExpression.Append(vector);

                if (moveNext = vectorsEnumerator.MoveNext())
                {
                    vectorExpression.Append(",");
                }
                else
                {
                    vectorExpression.Append(")");
                }
            }

            return vectorExpression.ToString();
        }
    }
}