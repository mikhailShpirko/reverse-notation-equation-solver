# Reverse Notation Equation Solver
This is solution for several practical tasks given as a part of the course "Information Systems Architect" by GeekBrains.ru 
  
The requirement was to create a Console app that will evaluate a Reverse Polish Notation math equation and show calculation result.

Supported operations: +, -, *, /, unary +, unary - 

Example:

Input: 1 2 + 4 * 3 +

Output: 15


Important note: the task had to be done using functional programming paradigm.

I attempted to implement the solution in both C# and F# (my first attempt to write in this programming language). 

C# solution follows functional programming paradigm by avoiding usage of local variables and use in method parameters. This follows referential transparency concept. Fianlly, I avoided using exceptions to handle validation and used a Struct that returns both result and error message in case of error.

F# solution is split to modules and uses recursion to evaluate the equation. This helped to avoid using Stack data structure.
