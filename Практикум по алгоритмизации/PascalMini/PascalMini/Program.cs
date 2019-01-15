using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class Program
{
    static Dictionary<string, double> VarStack =
        new Dictionary<string, double>();

    static void Run(in string rowline)
    {
        var state = State.Var;
        var line = Lexer.Split(rowline);
        string name = null;
        for (var j = 0; j < line.Count(); ++j)
        {
            var lexeme = line.ElementAt(j);
            if (state == State.Var)
            {
                if (lexeme.ToUpper() == "VAR")
                {
                    state = State.Name;
                    continue;
                }
                PascalRuntime.Error(
                    "ожидалось ключевое слово VAR в начале строки");
            }
            if (state == State.Name)
            {
                if (Char.IsLetter(lexeme.First()))
                {
                    name = lexeme;
                    state = State.Equal;
                    continue;
                }
                PascalRuntime.Error(
                    "ожидалось имя переменной после слова VAR");
            }
            if (state == State.Equal)
            {
                if (lexeme == ":=")
                {
                    state = State.Expression;
                    continue;
                }
                PascalRuntime.Error(
                    "ожидался оператор := после имени переменной");
            }
            if (state == State.Expression)
            {
                VarStack.Add(name, Calculator.Calculate(
                    line.Skip(j).Select(i =>
                        Char.IsLetter(i.First()) ?
                            VarStack[i].ToString() : i)
                    .ToList()
                ));
                return;
            }
        }
        PascalRuntime.Error("ожидалось выражение!");
    }

    static void Main()
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Console.Title = "PascalMini";
        while (true)
        {
            try
            {
                Run(Console.ReadLine());
                Console.WriteLine(
                    $"В стек добавлена переменная {VarStack.Last()}"
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

