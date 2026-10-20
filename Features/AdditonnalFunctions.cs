namespace Features.Functionhandler;

static class NewFunction
{
    internal static double Factorial(double n)
    {
        if (n < 0)
            throw new ArgumentException("Factorial is not defined for negative numbers.");
        if (n == 0 || n == 1)
            return 1;
        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    internal static int PGCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int reste = a % b;
            a = b;
            b = reste;
        }

        return a;
    }
    internal static int PPCM(int a, int b)
    {
        if (a == 0 || b == 0)
            return 0;

        return Math.Abs(a / PGCD(a, b) * b);
    }
    internal static int Comb(int n, int k)
    {
        if (k < 0 || k > n)
            return 0;

        if (k == 0 || k == n)
            return 1;

        k = Math.Min(k, n - k); // Take advantage of symmetry
        int c = 1;
        for (int i = 0; i < k; i++)
        {
            c = c * (n - i) / (i + 1);
        }
        return c;
    }
    internal static int Perm(int n, int k)
    {
        if (k < 0 || k > n)
            return 0;

        int p = 1;
        for (int i = 0; i < k; i++)
        {
            p *= (n - i);
        }
        return p;
    }
}