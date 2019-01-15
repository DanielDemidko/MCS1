using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Утилиты
/// </summary>
static class Utils
{
    /// <summary>
    /// Найти самый длинный отрезок
    /// </summary>
    /// <param name="space">Набор точек</param>
    /// <returns>Отрезок</returns>
    public static Segment? MaxSegment(this IEnumerable<Point> space)
    {
        Segment? result = null;
        for (var i = 0; i < space.Count(); ++i)
        {
            for (var j = i + 1; j < space.Count(); ++j)
            {
                var segment = new Segment(space.ElementAt(i), space.ElementAt(j));
                if (result == null || segment.Distance > result.Value.Distance)
                {
                    result = segment;
                }
            }
        }
        return result;
    }

    /// <summary>
    /// Определитель
    /// </summary>
    /// <param name="a">Матрица</param>
    /// <returns>Число</returns>
    public static double Determinant3(this double[,] a) =>
        a[0, 0] * a[1, 1] * a[2, 2] +
        a[0, 1] * a[1, 2] * a[2, 0] +
        a[1, 0] * a[2, 1] * a[0, 2] -
        a[0, 2] * a[1, 1] * a[2, 0] -
        a[1, 0] * a[0, 1] * a[2, 2] -
        a[2, 1] * a[1, 2] * a[0, 0];
}

