using System;
using System.Collections.Generic;
using System.Linq;

class Poligon
{
    private readonly List<Point> OrderedPoints;
    private int Index = -1;

    public int Length { get => OrderedPoints.Count; }

    public Point Next()
    {
        if (Index == OrderedPoints.Count() - 1)
        {
            Index = -1;
        }
        return OrderedPoints[++Index];
    }

    public Poligon(in List<Point> points)
    {
        OrderedPoints = points ?? throw new ArgumentNullException("points");
        if (points.Count() == 0)
        {
            throw new ArgumentException("points.Count() must be more then 0", "points");
        }
    }
}

