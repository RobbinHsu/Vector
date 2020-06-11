using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Vector
    {
        public int Dimension;

        //property
        //public int dimension;
        public double X;
        public double Y;
        public double Z;

        //method
        public Vector(List<double> a)
        {
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public string Tostring()
        {
            var x = "(" + X + "," + Y + "," + Z + ")";
            return x;
        }

        public Vector add(Vector v)
        {
            var result = new Vector(0,0,0);
            result.X = X + v.X;
            result.Y = Y + v.Y;
            result.Z = Z + v.Z;
            return result;
        }

        public Vector substract(Vector v)
        {
            var result = new Vector(0,0,0);
            result.X = X - v.X;
            result.Y = Y - v.Y;
            result.Z = Z - v.Z;
            return result;
        }

        public Vector subtract(Vector va)
        {
            throw new System.NotImplementedException();
        }

        public Vector scalarMultiplication(double d)
        {
            throw new System.NotImplementedException();
        }

        public object dotProduct(Vector vb)
        {
            throw new System.NotImplementedException();
        }
    }
}