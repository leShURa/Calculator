namespace Handler.Functionhandler;

class FunctionHandler{
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
    public List<string> CalculateFunctions(list<string> tokens)
    {
        for (int i = 0; i < tokens.Count - 1; i++)
        {
            if (functions.Contains(tokens[i]))
            {
                
            }
        }
    }
}