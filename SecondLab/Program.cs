using System;

namespace SecondLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double epsilon = 0.01;
            double step = 0.005;
            double[] x = { -1d, -2d };
            var ans1 = Descent.CoordinateDescent(Functions.Fxy, x, step, epsilon);
            Console.WriteLine($"{ans1[0]} {ans1[1]}\n");

            var ans2 = Descent.GradientDescent(Functions.Fxy, Functions.GradFxy, x, step, epsilon);
            Console.WriteLine($"{ans2[0]} {ans2[1]}\n");

            var ans3 = Descent.NewtonDescent(Functions.GradFxy, Functions.Hmatrix, x, epsilon);
            Console.WriteLine($"{ans3[0]} {ans3[1]}\n");
        }
    }
}
