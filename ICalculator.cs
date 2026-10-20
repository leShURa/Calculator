public interface ICalculator
{
    Func<string, List<string>> Tokenizer { get; }
    public List<string> CalculateFunctions(List<string> tokens);
    public List<string> CalculateWithParenthesis(List<string> tokens);
    public List<string> CalculateFactoriel(List<string> tokens);
    public List<string> CalculatePowAndSqrt(List<string> tokens);
    public List<string> CalculateMultiplicationAndDivision(List<string> tokens);
    public List<string> CalculateAdditionAndSubtraction(List<string> tokens);
}