using System;

namespace SecondLab
{
    public static class Utils
    {
        public static bool isEqual(double[] first, double[] second, double epsilon)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (Math.Abs(first[i] - second[i]) > epsilon)
                {
                    return false;
                }
            }
            return true;
        }
    }
}