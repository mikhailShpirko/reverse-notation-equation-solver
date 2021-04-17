module EquationEvaluation

open System
open MathOperations

let operations = ["+"; "-"; "*"; "/"]

let isOperation (equationItem: string) : bool = 
    List.exists(fun operation -> operation = equationItem) operations

let isOperand (equationItem: string) : bool = 
    Decimal.TryParse equationItem |> fst

let getOperation (operation: string) = 
    if operation = operations.[0] then
        add
    else if operation = operations.[1] then
        subtract
    else if operation = operations.[2] then
        multiply
    else
        divide

let rec evaluateList (equation: string list) : string list = 
    match List.tryFindIndex isOperation equation with
    | Some value -> 
        if value < 2 then equation
        else
            let b = equation.[value - 1]
            let a = equation.[value - 2]
            if isOperand b && isOperand a then
                let currentOperation = getOperation equation.[value]
                //as string list to merge lists for further evaluation
                let operationResult: string list = [currentOperation(Decimal.Parse a, Decimal.Parse b).ToString()]
                if value - 3 < 0 then
                    evaluateList(List.append operationResult equation.[value+1 ..])
                else
                    let beginningOfEquation = List.append equation.[0 .. value - 3] operationResult
                    evaluateList(List.append beginningOfEquation equation.[value+1 ..])
            else
                equation
    | None -> equation

let evaluate (equation: string list) : decimal * string = 
    let evaluatedEquation = evaluateList equation
    if evaluatedEquation.Length <> 1 || isOperand evaluatedEquation.[0] = false then
        ((decimal)0, "Invalid equation provided: not enough operations or operands")
    else
        (Decimal.Parse evaluatedEquation.[0], "")