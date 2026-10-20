namespace Handler.ParenthesisHandler;

class ParenthesisHandler
{
    internal List<string> HandleParenthesis(List<string> tokens)
    {
        while (tokens.Contains("("))
        {
            int openIndex = tokens.LastIndexOf("(");
            int closeIndex = tokens.IndexOf(")", openIndex);
            if (closeIndex == -1)
            {
                throw new InvalidDataException("Mismatched parentheses.");
            }

            

            tokens[openIndex] = result;
            tokens.RemoveRange(openIndex + 1, closeIndex - openIndex);
        }
        return tokens;
    }
}