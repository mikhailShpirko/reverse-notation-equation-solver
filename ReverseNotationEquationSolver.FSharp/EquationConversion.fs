module EquationConversion

open System

let convertStringToEquation (input: string) : string list = 
    Array.toList(input.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries))