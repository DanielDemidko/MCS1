using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Отрезок
/// </summary>
struct Segment
{
    public readonly Point A;
    public readonly Point B;
    public readonly double Distance;

    public override string ToString()
    {
        return $"Расстояние из {A} в {B} равно {Distance}";
    }

    public Segment(in Point a, in Point b)
    {
        A = a;
        B = b;
        Distance = Math.Sqrt(Math.Pow(B.Abscissa - A.Abscissa, 2) + Math.Pow(B.Ordinate - A.Ordinate, 2));
    }
}

