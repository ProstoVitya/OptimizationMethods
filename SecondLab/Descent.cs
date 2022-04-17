using System;

namespace SecondLab
{
    class Descent
    {
        public static double[] CoordinateDescent(Func<double[], double> f,
            double[] x, double step, double epsilon)
        {
            bool isDone = false;
            int iterations = 0;
            while (!isDone)
            {
                var xPrev = (double[])x.Clone();
                for (int i = 0; i < x.Length; i++)
                {
                    var xNew = (double[])x.Clone();
                    xNew[i] += step;
                    double fx = f(x);
                    double fxNew = f(xNew);

                    while (fxNew < fx)
                    {
                        x[i] = xNew[i];
                        fx = fxNew;
                        xNew[i] += step;
                        fxNew = f(xNew);
                        ++iterations;
                    }
                }
                isDone = Utils.isEqual(x, xPrev, epsilon);
            }
            Console.WriteLine("Iterations = " + iterations);
            return x;
        }

        public static double[] GradientDescent(Func<double[], double> f,
            Func<double[], double[]> gradF, double[] x, double step, double epsilon)
        {
            bool isDone = false;
            int iterations = 0;
            while (!isDone)
            {
                var xPrev = (double[])x.Clone();
                double fxPrev = f(xPrev);
                var gradFx = gradF(x);
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] -= step * gradFx[i];
                }
                double fx = f(x);
                while (fx < fxPrev)
                {
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] -= step * gradFx[i];
                    }
                    fxPrev = fx;
                    fx = f(x);
                    ++iterations;
                }
                isDone = Utils.isEqual(x, xPrev, epsilon);
            }
            Console.WriteLine("Iterations = " + iterations);
            return x;
        }

        public static double[] NewtonDescent(Func<double[], double> f,
            Func<double[], double[]> gradF, Func<double[], double[,]> h, double[] x, double epsilon)
        {
            bool isDone = false;
            int iterations = 0;
            while (!isDone)
            {
                var xPrev = (double[])x.Clone();
                Matrix matrix1 = h(x);
                matrix1 = matrix1.Inverse();
                var matrix2 = new Matrix(gradF(x));
                matrix2 = matrix1 * matrix2;
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] -= matrix2[i, 0];
                }
                ++iterations;
                isDone = Utils.isEqual(x, xPrev, epsilon);
            }
            Console.WriteLine("Iterations = " + iterations);
            return x;
        }
    }
}
