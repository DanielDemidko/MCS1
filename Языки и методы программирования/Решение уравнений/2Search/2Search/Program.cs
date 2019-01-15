using System;

class Program
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Console.Write("Введите функцию F(x): ");
        var search = new BinarySearch(new Fx(Console.ReadLine()));
        Console.Write("Введите погрешность приближения: ");
        Console.WriteLine(search.With(Double.Parse(Console.ReadLine())));
        Console.ReadKey();
    }
}
