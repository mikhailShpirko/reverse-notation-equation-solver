using System;

namespace ReverseNotationEquationSolver.CSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                //remove all previous input
                Console.Clear();
                Console.WriteLine("Enter Reverse Notation equation");
                try
                {
                    Console.WriteLine(new EquationEvaluator().Evaluate(Console.ReadLine()));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error occured: {e.Message}");
                }

                //prevent from closing
                Console.WriteLine("Press enter to repeat");
                Console.ReadLine();
            }
        }
    }
}
