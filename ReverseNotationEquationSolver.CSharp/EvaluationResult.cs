namespace ReverseNotationEquationSolver.CSharp
{
    public struct EvaluationResult
    {
        public readonly decimal Result;
        public readonly string ErrorMessage;
        public readonly bool IsSuccess;

        public EvaluationResult(decimal result)
        {
            Result = result;
            ErrorMessage = string.Empty;
            IsSuccess = true;
        }

        public EvaluationResult(string errorMessage)
        {
            Result = 0;
            ErrorMessage = errorMessage;
            IsSuccess = false;
        }

        public override string ToString()
        {
            return IsSuccess ? $"{Result}" : ErrorMessage;
        }
    }
}
