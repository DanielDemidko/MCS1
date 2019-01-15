using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    /// <summary>
    /// Метод упрощает матрицу
    /// </summary>
    /// <param name="matrix">Исходная матрица</param>
    /// <returns>Упрощённая матрица</returns>
    static IEnumerable<IEnumerable<int?>> Reduction(this IEnumerable<IEnumerable<int?>> matrix)
    {
        // Редукция строк
        var strMins = matrix.Select(Enumerable.Min);
        var result = matrix.Select((list, index) =>
            list.Select(item =>
            {
                if (item == null)
                {
                    return null;
                }
                return item - strMins.ElementAt(index);
            }));
        // Редукция столбцов
        var colMins = Enumerable
            .Range(0, result.Count())
            .Select(index => (result.Select(j => j.ElementAt(index)).Min()));
        return result.Select(list => list.Select((each, i) => each - colMins.ElementAt(i)));
    }

    /// <summary>
    /// Напечатать матрицу
    /// </summary>
    /// <param name="matrix">Матрица</param>
    static void PrintMatrix(in IEnumerable<IEnumerable<int?>> matrix)
    {
        foreach (var i in matrix)
        {
            foreach (var j in i)
            {
                Console.Write("{0, 7} |", j == null ? "M" : j.ToString());
                continue;
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Возвращает строку кроме одного элемента
    /// </summary>
    /// <param name="m">Матрица</param>
    /// <param name="i">Строка элемента</param>
    /// <param name="j">Колонка элемента</param>
    /// <returns>Строка</returns>
    static IEnumerable<int?> RowWithout(this IEnumerable<IEnumerable<int?>> m, int i, int j) =>
        m.ElementAt(i).Where((item, index) => index != j);

    /// <summary>
    /// Возвращает колонку кроме одного элемента
    /// </summary>
    /// <param name="m">Матрица</param>
    /// <param name="i">Строка элемента</param>
    /// <param name="j">Колонка элемента</param>
    /// <returns>Колонка</returns>
    static IEnumerable<int?> ColumnWithout(this IEnumerable<IEnumerable<int?>> m, int i, int j)
    {
        for(var k = 0; k < m.Count(); ++k)
        {
            if(k != i)
            {
                yield return m.ElementAt(k).ElementAt(j);
            }
        }
    }

    /// <summary>
    /// Возвращает оценку элемента
    /// </summary>
    /// <param name="m">Матрица</param>
    /// <param name="i">Строка элемента</param>
    /// <param name="j">Колонка элемента</param>
    /// <returns>Оценка</returns>
    static Mark GetMark(this IEnumerable<IEnumerable<int?>> m, int i, int j) =>
        new Mark(i, j, (m.RowWithout(i, j).Min() + m.ColumnWithout(i, j).Min()).Value);


    /// <summary>
    /// Возвращет оценки всех нулевых элементов
    /// </summary>
    /// <param name="m">Матрица</param>
    /// <returns>Оценки</returns>
    static IEnumerable<Mark> GetZeroMarks(this IEnumerable<IEnumerable<int?>> m)
    {
        for(int i = 0; i < m.Count(); ++i)
        {
            var list = m.ElementAt(i);
            for(int j = 0; j < list.Count(); ++j)
            {
                if(list.ElementAt(j) == 0)
                {
                    yield return m.GetMark(i, j);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        var matrix = System.IO.File
            .ReadAllLines("Matrix.txt")
            .Select(i => i
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(j => j == "-1" ? new int?() : Int32.Parse(j)));
        Console.WriteLine("1. Исходная матрица");
        PrintMatrix(matrix);
        Console.WriteLine("2. Проводим редукцию строк и столбцов");
        var reduct = matrix.Reduction();
        PrintMatrix(reduct);
        Console.WriteLine("3. Находим оценки нулевых элементов");
        var marks = reduct.GetZeroMarks().ToList();
        foreach(var i in marks.OrderByDescending(m=> m.Value))
        {
            Console.WriteLine(i);
        }
        var used = new List<Mark> { marks.Max() };
        for(int i = 0; i < matrix.Count() - 1; ++i)
        {
            Console.WriteLine($"{used.Last().I + 1} -> {used.Last().J + 1}");
            used.Add(marks.Find(m => m.I == used.Last().J && !used.Contains(m)));
        }
    }
}
