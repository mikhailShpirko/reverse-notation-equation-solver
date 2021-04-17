module ApplicationLoop

open System
open EquationConversion
open EquationEvaluation

let getInput() =
    Console.ReadLine()

let printOutput (s:string) =
    printfn "%s" s

let rec appLoop() =
    Console.Clear()
    printOutput "Enter Reverse Notation equation"
    let input = getInput()
    let equation = convertStringToEquation input
    let evaluationResult = evaluate equation
    let errorMessage = evaluationResult |> snd
    if errorMessage <> "" then
        printOutput errorMessage
    else 
        Console.WriteLine(evaluationResult |> fst)
    printOutput "Press Enter to repeat"
    getInput()
    appLoop()