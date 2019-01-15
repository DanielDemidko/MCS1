using System;
using System.Linq;

/// <summary>
/// Точка
/// </summary>
struct Point
{
    /// <summary>
    /// X
    /// </summary>
    public readonly double Abscissa;
    /// <summary>
    /// Y
    /// </summary>
    public readonly double Ordinate;

    public override string ToString()
    {
        return $"({Abscissa}; {Ordinate})";
    }

    public Point(in double x, in double y)
    {
        Abscissa = x;
        Ordinate = y;
    }

    /// <summary>
    /// Конструирует точку из строки с координатами вида "x y"
    /// </summary>
    /// <param name="xy">строка с координатами</param>
    public Point(in string xy) : this(xy.Split())
    {
    }

    // Приватные конструкторы для технических нужд
    private Point(in string x, in string y) : this(Double.Parse(x), Double.Parse(y))
    {
    }

    private Point(in string[] arr) : this(arr.First(), arr.Last())
    {
    }
}

