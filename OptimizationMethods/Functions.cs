using System;

namespace OptimizationMethods
{
    public static class Functions
    {
        public static double F1(double x)
        {
            return 10 - 1 / Math.Cosh(Math.Pow(x - 3, 2));
        }

        public static double F2(double x)
        {
            return 1 / (1 + Math.Exp(-5 * x * x + 10 * x));
        }

        public static double F3(double x)
        {
            return Math.Tanh(Math.Pow(x, 4) - 2 * x);
        }

        public static double F4(double x)
        {
            return -1 / (1 + Math.Pow(x, 6));
        }
    }
}
