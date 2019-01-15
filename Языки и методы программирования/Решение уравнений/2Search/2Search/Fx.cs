using DynamicExpresso;

// Инкапсулируем f(x)
class Fx
{
    // Интерпретатор C#
    private readonly Interpreter Cs = new Interpreter();
    // Выражение C#, f(x)
    private readonly string F;

    public double With(in double x) =>
        Cs.Eval<double>(F, new Parameter("x", x));

    public Fx(in string f)
    {
        F = f;
    }
}

