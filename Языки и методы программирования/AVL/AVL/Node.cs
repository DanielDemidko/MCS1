class Node
{
    public int Key { get; }
    public int Height { set; get; }
    public Node Right { set; get; }
    public Node Left { set; get; }

    public Node(in int key)
    {
        Key = key;
        Height = 1;
    }
}

