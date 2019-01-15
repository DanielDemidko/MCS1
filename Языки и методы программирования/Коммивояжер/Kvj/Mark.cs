struct Mark : System.IComparable<Mark>
{
    public int I { get; }
    public int J { get; }
    public int Value { get; }

    public override string ToString() =>
        $"({I + 1}, {J + 1}): {Value}";

    public int CompareTo(Mark other) =>
        Value > other.Value ? 1 : Value < other.Value ? -1 : 0;

    public Mark(in int i, in int j, in int val)
    {
        I = i;
        J = j;
        Value = val;
    }
}
