module ApplicationLoop

open System
open EquationConversion
open EquationEvaluation

let rec appLoop() =
    Console.Clear()
    Console.WriteLine "Enter Reverse Notation equation"
    let input = Console.ReadLine()
    let equation = convertStringToEquation input
    let evaluationResult = evaluate equation
    let errorMessage = evaluationResult |> snd
    if errorMessage <> "" then
        Console.WriteLine errorMessage
    else 
        Console.WriteLine(evaluationResult |> fst)
    Console.WriteLine "Press Enter to repeat"
    Console.ReadLine()
    appLoop()