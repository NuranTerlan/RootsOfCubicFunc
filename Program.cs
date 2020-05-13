using System;
using System.Collections.Generic;

namespace CubeXFunction
{
    class Program
    {
        public static double NthRoot(double A, int N)
        {
            return Math.Pow(A, 1.0 / N);
        }

        public static List<double> Discrimination(double a, double b, double c)
        {
            double temp = default(double);
            List<double> result = new List<double>();
            double root = default(double);
            temp = b * b - 4 * a * c;
            if (temp < 0)
            {
                Console.WriteLine($"This function * ({a})x^2+({b})x+({c})=0 * hasn't any solution !");
            }
            else if (temp == 0)
            {
                root = -(b) / (2 * a);
                result.Add(root);
                return result;
            }

            temp = Math.Sqrt(temp);
            root = (-(b) + temp) / (2 * a);
            result.Add(root);
            root = (-(b) - temp) / (2 * a);
            result.Add(root);
            return result;
        }

        public static List<double> CheckAllPossibleRoots(double a, double b, double c, double d)
        {
            List<double> allPossibleRootsP = new List<double>();
            List<double> allPossibleRootsQ = new List<double>();
            List<double> realRoots = new List<double>();

            for (double i = 1; i <= Math.Abs(d); i++)
            {
                if (d % i == 0)
                    allPossibleRootsP.Add(i);
            }

            for (double j = 1; j <= Math.Abs(a); j++)
            {
                if (d % j == 0)
                    allPossibleRootsQ.Add(j);
            }

            foreach (var rootQ in allPossibleRootsQ)
            {
                foreach (var rootP in allPossibleRootsP)
                {
                    double ratioRoot = rootP / rootQ;

                    if (((((ratioRoot * a + b) * ratioRoot) + c) * ratioRoot) + d == 0)
                    {
                        foreach (var root in Discrimination(a, (ratioRoot * a + b), (((ratioRoot * a + b) * ratioRoot) + c)))
                        {
                            realRoots.Add(root);
                        }
                        realRoots.Add(ratioRoot);
                        return realRoots;
                    }
                    else if ((((((-ratioRoot) * a + b) * (-ratioRoot)) + c) * (-ratioRoot)) + d == 0)
                    {
                        foreach (var root in Discrimination(a, ((-ratioRoot) * a + b), ((((-ratioRoot) * a + b) * (-ratioRoot)) + c)))
                        {
                            realRoots.Add(root);
                        }
                        realRoots.Add(-ratioRoot);
                        return realRoots;
                    }
                }
            }
            return realRoots;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ******************** Please enter coefficients of your cubic function => ******************** \n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" coefficient( x^3 ) : ");
            double coefficient1 = double.Parse(Console.ReadLine());
            Console.Write(" coefficient( x^2 ) : ");
            double coefficient2 = double.Parse(Console.ReadLine());
            Console.Write(" coefficient( x ) : ");
            double coefficient3 = double.Parse(Console.ReadLine());
            Console.Write(" coefficient( without any x ) : ");
            double coefficient4 = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" \n******************** Function =>  ~ ({coefficient1})x^3 + ({coefficient2})x^2 + ({coefficient3})x + ({coefficient4}) ~ ******************** \n\n");

            Console.ForegroundColor = ConsoleColor.Red;
            List<double> roots = CheckAllPossibleRoots(coefficient1, coefficient2, coefficient3, coefficient4);
            int count = 1;
            foreach (var root in roots)
            {
                Console.WriteLine($" ******************** Root-{count} : {root}\n");
                count++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
