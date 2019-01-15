using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество точек: ");
        var poligon = new Poligon(Enumerable
                .Range(1, Int32.Parse(Console.ReadLine()))
                .Select(i =>
                {
                    Console.Write($"{i}. x и y: ");
                    return new Point(Console.ReadLine());
                }).ToList());
        var products = Enumerable
            .Range(0, Math.DivRem(poligon.Length, 3, out int rest) + rest)
            .Select(i =>
            {
                var a = poligon.Next();
                var b = poligon.Next();
                var c = poligon.Next();
                var ab = (x: b.X - a.X, y: b.Y - a.Y);
                var bc = (x: c.X - b.X, y: c.Y - b.Y);
                return ab.x * bc.y - ab.y * bc.x;
            });
        Console.WriteLine(products.All(i => i == products.First()) ? "Выпуклый" : "Невыпуклый");
        Console.ReadKey();
    }
}

