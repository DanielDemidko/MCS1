using System;
using System.Collections.Generic;

static class Converter
{
    private static Int32 GetLevel(String symbol) =>
        symbol == "^" ? 3 : 
        symbol == "*" || symbol == "/" ? 2 : 
        symbol == "+" || symbol == "-" ? 1 : 
        0;

    public static List<String> ToRPNotation(
        in IEnumerable<String> expression)
    {
        List<String> result = new List<String>();
        Stack<String> operators = new Stack<String>();
        foreach (String i in expression)
        {
            switch (i)
            {
                case "(":
                    operators.Push(i);
                    continue;
                case ")":
                    while (operators.Count > 0 && 
                        operators.Peek() != "(")
                    {
                        result.Add(operators.Pop());
                    }
                    operators.Pop();
                    continue;
                case "*":
                case "/":
                case "+":
                case "-":
                case "^":
                    while (operators.Count > 0 && 
                        GetLevel(operators.Peek()) >= GetLevel(i))
                    {
                        result.Add(operators.Pop());
                    }
                    operators.Push(i);
                    continue;
            }
            result.Add(i);
        }
        while (operators.Count > 0)
        {
            result.Add(operators.Pop());
        }
        return result;
    }
}

