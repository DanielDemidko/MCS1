using System;
using System.IO;
using System.Linq;

/// <summary>
/// Программа находит наименьшую окружность, которая включает в себя все точки из файла input.txt
/// Файл input.txt должен содержать набор строк, на каждой два числа - координаты точки
/// Проверить валидность результата можно на этом сайте: 
/// https://wpcalc.com/uravnenie-okruzhnosti-po-trem-tochkam/
/// </summary>
class Program
{
    static void Main()
    {
        // ui
        Console.WriteLine("Считываем все точки из файла 'input.txt':");

        // Считываем все точки
        var allPoints = File.ReadAllLines("input.txt").Select(i => new Point(i));

        // ui
        foreach (var i in allPoints) Console.WriteLine("    " + i);
        Console.Write("\nИщем самый длинный отрезок:\n    ");

        // Находим самый длинный отрезок
        var maxSegment = allPoints.MaxSegment().Value;

        // ui
        Console.WriteLine(maxSegment);
        Console.Write("\nСтроим окружность с этим диаметром:\n    ");

        // Строим по нему круг
        var circle = new Circle(maxSegment);

        // ui
        Console.WriteLine(circle);
        Console.Write("\nИщем самую далёкую точку за пределами окружности:\n    ");

        // Находим самую далекую точку за пределами круга
        var remotest = circle.RemotestPoint(allPoints);

        // ui
        Console.WriteLine(
            remotest == null ? "Такая точка не найдена!" : remotest.ToString());
        Console.Write("\nСтроим финальную окружность на основании всех предыдущих точек:\n    ");

        // Если такой нет, выводим ответ
        // Иначе строим новый круг описывающий треугольник от трёх точек
        Console.WriteLine
        (
            remotest == null ? circle : new Circle(new Triangle(maxSegment.A, maxSegment.B, remotest.Value))
        );
    }
}

