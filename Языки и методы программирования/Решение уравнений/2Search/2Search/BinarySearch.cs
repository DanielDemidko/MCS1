using System;
using System.Linq;

class BinarySearch
{
    private readonly Fx F;
    private readonly int Left;
    private readonly int Right;

    public double With(in double eps)
    {
        Console.WriteLine($"Находим корень выражения с погрешностью {eps} . . .");
        double left = Left;
        double right = Right;
        while (Math.Abs(right) - Math.Abs(left) < eps)
        {
            Console.Write($"[{left}, {right}] -> ");
            var x = (left + right) / 2;
            Console.Write($"{x}\n");
            var y = F.With(x);
            if(y == 0)
            {
                return x;
            }
            if (y > 0)
            {
                right = x;
            }
            else
            {
                left = x;
            }
        }
        return (left + right) / 2;
    }

    public BinarySearch(in Fx f)
    {
        F = f ?? throw new ArgumentNullException("f");
        Console.WriteLine("Прогоняем функцию на тестовом промежутке [-300, 300] . . .");
        var xs = Enumerable.Range(-300, 300);
        Left = xs.First(x => F.With(x) < 0);
        Right = xs.First(x => F.With(x) > 0);
        Console.WriteLine($"Найдены правые и левые границы [{Left}, {Right}]");
    }
}
