using System;

namespace OptimizationMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FindMinByDichotomy");
            TextExamples(FindMinByDichotomy);
            Console.WriteLine("\nFindMinByGold");
            TextExamples(FindMinByGold);
            Console.WriteLine("\nFindMinByFibbonachi");
            TextExamples(FindMinByFibbonachi);
        }

        private static double FindMinByDichotomy(double a, double b, Func<double, double> f, double epsilon, double precision)
        {
            int count = 0;
            while (Math.Abs(a - b) > precision)
            {
                count+=2;
                double x = (a + b) / 2;
                double F1 = f(x - epsilon / 2);
                double F2 = f(x + epsilon / 2);
                if
                    (F1 < F2) b = x + epsilon / 2;
                else
                    a = x - epsilon / 2;
            }
            Console.WriteLine("Interations count:" + count);
            return (a + b) / 2;
        }

        private static double FindMinByGold(double a, double b, Func<double, double> f, double epsilon, double t)
        {
            int count = 2;
            double f1 = f(Math.Abs(a - b) * 0.382 + a);
            double f2 = f(Math.Abs(a - b) * 0.618 + a);
            while (Math.Abs(a - b) > epsilon)
            {
                ++count;
                if (f1 < f2)
                {
                    b = Math.Abs(a - b) * 0.618 + a;
                    f2 = f1;
                    f1 = f(Math.Abs(a - b) * 0.382 + a);
                }
                else
                {
                    a = Math.Abs(a - b) * 0.382 + a;
                    f1 = f2;
                    f2 = f(Math.Abs(a - b) * 0.618 + a);
                }
            }
            Console.WriteLine("Interations count:" + count);
            return (a + b) / 2;
        }

        private static double FindMinByFibbonachi(double a, double b, Func<double, double> f, double epsilon, double t)
        {
            int n = 12;
            double f1 = Fibbonachi(n - 1), f2 = Fibbonachi(n + 1), f3 = Fibbonachi(n);
            double x1 = a + f1 / f2 * (b - a), x2 = a + f3 / f2 * (b - a);
            double y1 = f(x1);
            double y2 = f(x2);
            for (int i = 0; i < n; i++)
            {  
                if (y1 > y2)
                {
                    a = x1;
                    x1 = x2;
                    x2 = b - (x1 - a);
                    y1 = y2;
                    y2 = f(x2);
                }
                else
                {
                    b = x2;
                    x2 = x1;
                    x1 = a + (b - x2);
                    y2 = y1;
                    y1 = f(x1);
                }
            }
            Console.WriteLine("Interations count:" + n);
            return (x1 + x2) / 2;
        }

        private static int Fibbonachi(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibbonachi(n - 1) + Fibbonachi(n - 2);
        }

        private static void TextExamples(Func<double, double, Func<double, double>, double, double, double> method)
        {
            Console.WriteLine("First function: " + method(-10, 10, Functions.F1, 0.25, 0.5));
            Console.WriteLine("Second function: " + method(-2, 3, Functions.F2, 0.25, 0.5));
            Console.WriteLine("Third function: " + method(-2, 2, Functions.F3, 0.25, 0.5));
            Console.WriteLine("Fourth function: " + method(-10, 10, Functions.F4, 0.25, 0.5));
        }
    }
}
