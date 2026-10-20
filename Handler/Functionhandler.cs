using System.Text;

namespace Handler.Functionhandler;

class FunctionHandler{
    public static double Factorial(double n)
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
    public static int PGCD(int a, int b)
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
    static int PPCM(int a, int b)
    {
        if (a == 0 || b == 0)
            return 0;

        return Math.Abs(a / PGCD(a, b) * b);
    }
    static int Comb(int n, int k)
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
    static int Perm(int n, int k)
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
    public HashSet<string> functions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "ln",
        "log",
        "abs",
        "sin",
        "exp",
        "cos",
        "tan",
        "min",
        "max",
        "gcd",
        "lcm",
        "pow",
        "root",
        "sqrt",
        "asin",
        "acos",
        "cbrt",
        "sinh",
        "cosh",
        "tanh",
        "comb",
        "perm",
        "ceil",
        "atan",
        "floor",
        "round",
        "trunc",
        "asinh",
        "acosh",
        "atanh",
        "logbase",
        "factorial"
    };
    public async Task<List<string>> FunctionParsing(List<string> tokens)
    {
        for (int i = 0; i < tokens.Count - 1; i++)
        {
            if (functions.Contains(tokens[i]))
            {
                int firstParenthesisIndex = tokens.IndexOf("(", i);
                if (firstParenthesisIndex != -1)
                {
                    int closingParenthesisIndex = tokens.IndexOf(")", firstParenthesisIndex);
                    if (closingParenthesisIndex != -1)
                    {
                        List<string> Param = new List<string>();
                        for (int j = firstParenthesisIndex + 1; j < closingParenthesisIndex; j++)
                        {
                            Param.Append(tokens[j]);
                        }
                        StringBuilder FunctionName = new StringBuilder();
                        for (int t = i; t < firstParenthesisIndex; t++)
                        {
                            FunctionName.Append(tokens[t]);
                        }
                        double functionResult = ExecuteFunctions(FunctionName.ToString(), Param.Select(double.Parse).ToList());
                        tokens[i] = functionResult.ToString();
                        tokens.RemoveAt(i + 1);
                        tokens.RemoveAt(i + 1);
                    }
                }
            }
        }
        throw new InvalidDataException();
    }
    public double ExecuteFunctions(string functionName, List<double> args)
    {
        double result = functionName.ToLower() switch
        {
            "ln"        => Math.Log(args[0]),
            "log"       => Math.Log10(args[0]),
            "abs"       => Math.Abs(args[0]),
            "sin"       => Math.Sin(args[0]),
            "cos"       => Math.Cos(args[0]),
            "tan"       => Math.Tan(args[0]),
            "exp"       => Math.Exp(args[0]),
            "sqrt"      => Math.Sqrt(args[0]),
            "cbrt"      => Math.Cbrt(args[0]),
            "asin"      => Math.Asin(args[0]),
            "acos"      => Math.Acos(args[0]),
            "atan"      => Math.Atan(args[0]),
            "sinh"      => Math.Sinh(args[0]),
            "cosh"      => Math.Cosh(args[0]),
            "tanh"      => Math.Tanh(args[0]),
            "ceil"      => Math.Ceiling(args[0]),
            "floor"     => Math.Floor(args[0]),
            "round"     => Math.Round(args[0]),
            "trunc"     => Math.Truncate(args[0]),

            "min"       => Math.Min(args[0], args[1]),
            "max"       => Math.Max(args[0], args[1]),
            "pow"       => Math.Pow(args[0], args[1]),
            "root"      => Math.Pow(args[0], 1.0 / args[1]),
            "factorial" => Factorial((int)args[0]),
            "logbase"   => Math.Log(args[0], args[1]),
            "acosh"     => Math.Acosh(args[0]),
            "asinh"     => Math.Asinh(args[0]),
            "atanh"     => Math.Atanh(args[0]),
            "gcd"       => PGCD((int)args[0], (int)args[1]),
            "lcm"       => PPCM((int)args[0], (int)args[1]),
            "comb"      => Comb((int)args[0], (int)args[1]),
            "perm"      => Perm((int)args[0], (int)args[1]),
            _ => throw new NotImplementedException(
                $"Le calcul de {functionName} n'est pas encore implémenté.")
        };
        return result;
    }
}
