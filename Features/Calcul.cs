namespace Features.Calcul;

class Calcul
{
    internal static double Calculate(double t1, string op, double t2)
    {
        return op switch
        {
            "+" => t1 + t2,
            "-" => t1 - t2,
            "*" => t1 * t2,
            "/" => t1 / t2,
            _ => throw new InvalidDataException($"Invalid operator: {op}"),
        };
    }
    internal static List<string> CalculateWithoutPriority(List<string> tokens)
    {
        for (int i = 0; i < tokens.Count - 1; i++)
        {
            if (tokens[i] == "+" || tokens[i] == "-")
            {
                double t1 = double.Parse(tokens[i - 1]);
                string op = tokens[i];
                double t2 = double.Parse(tokens[i + 1]);
                double result = Calculate(t1, op, t2);
                tokens[i - 1] = result.ToString();
                tokens.RemoveAt(i);
                tokens.RemoveAt(i);
                i--;
            }
        }
        return tokens;
    }
    internal static List<string> CalculateWithPriority(List<string> tokens)
    {
        for (int i = 0; i < tokens.Count - 1; i++)
        {
            if (tokens[i] == "*" || tokens[i] == "/")
            {
                double t1 = double.Parse(tokens[i - 1]);
                string op = tokens[i];
                double t2 = double.Parse(tokens[i + 1]);
                double result = Calculate(t1, op, t2);
                tokens[i - 1] = result.ToString();
                tokens.RemoveAt(i);
                tokens.RemoveAt(i);
                i--;
            }
        }
        return tokens;
    }
}