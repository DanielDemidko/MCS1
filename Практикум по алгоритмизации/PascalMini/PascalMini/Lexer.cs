using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Класс для лексического анализа подготовленных строк с кодом
/// </summary>
static class Lexer
{
    private static int CharIndex = 0;

    private static void Error(in string message) =>
        PascalRuntime.Error(
            "во время разбиения на лексемы, " +
            $"на символе {CharIndex} {message}");

    private static void MoveBuffer(
        this List<string> list,
        in StringBuilder buffer)
    {
        if (buffer.Length > 0)
        {
            list.Add(buffer.ToString());
            buffer.Clear();
        }
    }

    /// <summary>
    /// Функция разбивает строку на лексемы языка Pascal
    /// </summary>
    /// <param name="line">Строка кода</param>
    /// <returns>Список лексем</returns>
    public static IEnumerable<string> Split(in string line)
    {
        var result = new List<string>();
        var buffer = new StringBuilder();
        for (var i = 0; i < line.Length; ++i)
        {
            CharIndex = i + 1;
            var ch = line[i];
            // :=
            if (ch == ':' && line.ElementAtOrDefault(i + 1) == '=')
            {
                result.MoveBuffer(buffer);
                result.Add(":=");
                ++i;
                continue;
            }

            // Обработка символов
            if (ch == '\'')
            {
                buffer.Append('\'');
                buffer.Append(line.ElementAtOrDefault(i + 1));
                if (line.ElementAtOrDefault(i + 2) != '\'')
                {
                    Error("ожидался символ с закрывающей кавычкой '");
                }
                buffer.Append('\'');
                result.MoveBuffer(buffer);
                i = i + 2;
                continue;
            }
            // Дробные числа .
            if (ch == '.' && buffer.Length > 0 &&
                Char.IsDigit(buffer[0]) &&
                Char.IsDigit(line.ElementAtOrDefault(i + 1)))
            {
                buffer.Append('.');
                for (++i;
                    i < line.Length && Char.IsDigit(line[i]); ++i)
                {
                    buffer.Append(line[i]);
                }
                result.MoveBuffer(buffer);
                --i;
                continue;
            }
            // == >= <= !=
            if ("=><!".Contains(ch) &&
                line.ElementAtOrDefault(i + 1) == '=')
            {
                result.MoveBuffer(buffer);
                result.Add($"{ch}=");
                ++i;
                continue;
            }
            // Обработка строк
            if (ch == '\"')
            {
                var nextIndex = line.IndexOf('\"', i + 1);
                if (nextIndex == -1)
                {
                    Error("Не найден завершающий символ");
                }
                result.MoveBuffer(buffer);
                result.Add(line.Substring(i, nextIndex - i + 1));
                i = nextIndex;
                continue;
            }
            // Список символов которые нужно добавить
            // как отдельную лексему
            if (Char.IsPunctuation(ch) || Char.IsSymbol(ch))
            {
                result.MoveBuffer(buffer);
                result.Add(ch.ToString());
                continue;
            }
            // Пробел
            if (Char.IsWhiteSpace(ch))
            {
                result.MoveBuffer(buffer);
                continue;
            }
            // Всё остальное
            buffer.Append(ch);
        }
        result.MoveBuffer(buffer);
        return result;
    }
}

