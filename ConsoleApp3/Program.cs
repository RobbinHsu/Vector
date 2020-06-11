using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var a = new List<double>();
            a.Add(1);
            a.Add(3);
            a.Add(5);
            double[] bTemp = {2, 4, 6};
            var b = new List<double>(bTemp);

            var Va = new Vector(a);
            var Vb = new Vector(b);

            Console.WriteLine("The dimension of the Vector Va is: " + Va.Dimension);
            Console.WriteLine("Vector Va is: " + Va.ToString());

            Console.WriteLine("The dimension of the Vector Vb is:" + Vb.Dimension);
            Console.WriteLine("Vector Vb is: " + Vb.ToString());

            var Vc = Va.add(Vb);
            Console.WriteLine("Va+Vb=" + Vc.ToString());

            var Vd = Vb.subtract(Va);
            Console.WriteLine("Vb-Va=" + Vd.ToString());

            var Ve = Vb.scalarMultiplication(3.00);
            Console.WriteLine("3xVb=" + Ve.ToString());

            Console.WriteLine("Va.Vb=" + Va.dotProduct(Vb));

            double[] cTemp = {3, 3};
            var c = new List<double>(cTemp);
            var Vf = new Vector(c);
            Console.WriteLine("The dimension of the Vector Vf is:" + Vf.Dimension);
            Console.WriteLine("Vector Vf is: " + Vf.ToString());

            Console.Write("Va+Vf=");
            try
            {
                var Vg = Va.add(Vf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The dimensions of the two vectors do not match");
            }

            Console.ReadKey();
        } //end main
    }
}