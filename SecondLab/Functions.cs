using System;

namespace SecondLab
{
    public class Functions
    {
        public static double Fxy(double[] x)
        {
            return Math.Pow(x[0] - Math.Sqrt(2), 2) + Math.Pow(x[1] + Math.Sqrt(3), 2);
        }

        public static double[] GradFxy(double[] x)
        {
            double[] result = new double[] { 2d * (x[0] - Math.Sqrt(2)), 2d * (x[1] + Math.Sqrt(3)) };
            return result;
        }

        public static double[,] Hmatrix(double[] x)
        {
            double[,] matrix = { { 2d, 0d }, { 0d, 2d } };
            return matrix;
        }
    }
}
