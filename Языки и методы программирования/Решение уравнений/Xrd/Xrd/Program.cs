using System;

class ChordsMethod
{
    private readonly Fx F;

    public double With(in double eps, double a, double b)
    {
        while(true)
        {
            Console.WriteLine($"[{a}, {b}]");
            var c = a - (F.With(a) / (F.With(a) - F.With(b))) * (a - b);
            if(F.With(c) <= eps)
            {
                Console.WriteLine("Найден корень!");
                return c;
            }
            b = a;
            a = c;
        }
    }

    public ChordsMethod(in Fx f)
    {
        F = f ?? throw new ArgumentNullException("f");
    }
}

class Program
{
    static (double, double) ReadABLoop(in Fx f)
    {
        (double, double) ReadAB()
        {
            Console.Write("От: ");
            var prev = Double.Parse(Console.ReadLine());
            Console.Write("До: ");
            return (prev, Double.Parse(Console.ReadLine()));
        }
        (var a, var b) = ReadAB();
        while(f.With(a) * f.With(b) >= 0)
        {
            Console.WriteLine("A, B не удовлетворяют условию f(a) * f(b) < 0\nВведите их ещё раз.");
            (a, b) = ReadAB();
        }
        return (a, b);
    }

    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Console.Write("Введите функцию F(x): ");
        var f = new Fx(Console.ReadLine());
        Console.Write("Введите погрешность приближения: ");
        var eps = Double.Parse(Console.ReadLine());
        (var a, var b) = ReadABLoop(f);
        Console.WriteLine(new ChordsMethod(f).With(eps, a, b));
        Console.ReadKey();
    }

}

