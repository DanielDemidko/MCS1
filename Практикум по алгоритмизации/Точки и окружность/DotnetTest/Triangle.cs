using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Треугольник
/// </summary>
struct Triangle
{
    public readonly Point A;
    public readonly Point B;
    public readonly Point C;
    public readonly double Square;

    public Triangle(in Point a, in Point b, in Point c)
    {
        A = a;
        B = b;
        C = c;
        var segmentA = new Segment(a, b);
        var segmentB = new Segment(b, c);
        var segmentC = new Segment(c, a);
        var p = (segmentA.Distance + segmentB.Distance + segmentC.Distance) / 2;
        Square = Math.Sqrt(p * (p - segmentA.Distance) * (p - segmentB.Distance) * (p - segmentC.Distance));
    }
}

