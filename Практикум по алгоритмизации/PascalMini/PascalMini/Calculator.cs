using System;
using System.Collections.Generic;

static class Calculator
{
    public static Double Calculate(in List<string> line)
    {
        for (Int32 i = -1; (i = line.IndexOf("-", i + 1)) != -1;)
        {
            if (i == 0 || line[i - 1] == "(")
            {
                line.Insert(i, "0");
            }
        }
        Stack<Double> result = new Stack<Double>();
        foreach (String i in Converter.ToRPNotation(line))
        {
            if (Char.IsDigit(i[0]))
            {
                result.Push(Convert.ToDouble(i));
                continue;
            }
            Double b = result.Pop();
            Double a = result.Pop();
            result.Push(
                  i == "+" ? a + b
                : i == "-" ? a - b
                : i == "*" ? a * b
                : i == "/" ? a / b
                : i == "^" ? Math.Pow(a, b)
                : 0);
        }
        return result.Count > 0 ? result.Pop() : 0;
    }
}
