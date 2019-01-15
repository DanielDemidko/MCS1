using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/// <summary>
/// Круг
/// </summary>
struct Circle
{
    public readonly Point Center;
    public readonly double Radius;

    /// <summary>
    /// Метод возвращает самую далёкую точку за пределами круга или null если такой нет
    /// </summary>
    /// <param name="space">Набор точек</param>
    /// <returns>Самая далёкая точка за кругом</returns>
    public Point? RemotestPoint(in IEnumerable<Point> space)
    {
        Segment? result = null;
        foreach (var p in space)
        {
            var segment = new Segment(Center, p);
            if (segment.Distance > Radius && (result == null || segment.Distance > result.Value.Distance))
            {
                result = segment;
            }
        }
        if (result.HasValue)
        {
            return result.Value.B;
        }
        return null;
    }

    public override string ToString()
    {
        return $"O = {Center}; R = {Radius}";
    }

    public Circle(in Segment diameter)
    {
        Center = new Point(
            (diameter.A.Abscissa + diameter.B.Abscissa) / 2,
            (diameter.A.Ordinate + diameter.B.Ordinate) / 2);
        Radius = diameter.Distance / 2;
    }

    public Circle(in Triangle triangle)
    {
        var prefix = 1 / (4 * triangle.Square);
        Center = new Point
        (
            prefix * new double[,]
            {
                { Math.Pow(triangle.A.Abscissa, 2) + Math.Pow(triangle.A.Ordinate, 2), triangle.A.Ordinate, 1 },
                { Math.Pow(triangle.B.Abscissa, 2) + Math.Pow(triangle.B.Ordinate, 2), triangle.B.Ordinate, 1 },
                { Math.Pow(triangle.C.Abscissa, 2) + Math.Pow(triangle.C.Ordinate, 2), triangle.C.Ordinate, 1 },
            }.Determinant3(),

            (-prefix) * new double[,]
            {
                { Math.Pow(triangle.A.Abscissa, 2) + Math.Pow(triangle.A.Ordinate, 2), triangle.A.Abscissa, 1 },
                { Math.Pow(triangle.B.Abscissa, 2) + Math.Pow(triangle.B.Ordinate, 2), triangle.B.Abscissa, 1 },
                { Math.Pow(triangle.C.Abscissa, 2) + Math.Pow(triangle.C.Ordinate, 2), triangle.C.Abscissa, 1 },
            }.Determinant3()
        );
        Radius = new Segment(Center, triangle.A).Distance;
    }
}

