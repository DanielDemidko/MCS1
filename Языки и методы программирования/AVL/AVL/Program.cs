using System;
using System.Linq;

static class Program
{
    static int Height(this Node n) => n?.Height ?? 0;

    static int BalanceFactor(this Node n) => n.Right.Height() - n.Left.Height();

    static void CorrectHeight(this Node n)
    {
        var l = n.Left.Height();
        var r = n.Right.Height();
        n.Height = ((l > r) ? l : r) + 1;
    }

    static Node RightRotate(this Node p)
    {
        var q = p.Left;
        p.Left = q.Right;
        q.Right = p;
        q.CorrectHeight();
        p.CorrectHeight();
        return p;
    }

    static Node LeftRotate(this Node q)
    {
        var p = q.Right;
        q.Right = p.Left;
        p.Left = q;
        q.CorrectHeight();
        p.CorrectHeight();
        return q;
    }

    static Node Balance(this Node p)
    {
        p.CorrectHeight();
        if (p.BalanceFactor() == 2)
        {
            if (p.Right.BalanceFactor() < 0)
            {
                p.Right = p.Right.RightRotate();
            }
            return p.LeftRotate();
        }
        if (p.BalanceFactor() == -2)
        {
            if (p.Left.BalanceFactor() > 0)
            {
                p.Left = p.LeftRotate();
            }
            return p.RightRotate();
        }
        return p;
    }

    static Node Insert(this Node p, in int k)
    {
        if (p == null)
        {
            return new Node(k);
        }
        if (k < p.Key)
        {
            p.Left = p.Left.Insert(k);
        }
        else
        {
            p.Right = p.Right.Insert(k);
        }
        return p.Balance();
    }

    static Node Min(this Node p) => p.Left?.Min() ?? p;

    static Node EraseMin(this Node p)
    {
        if(p.Left == null)
        {
            return p.Right;
        }
        p.Left = p.Left.EraseMin();
        return p.Balance();
    }

    static Node Remove(this Node p, in int k)
    {
        if(p == null)
        {
            return null;
        }
        if(k < p.Key)
        {
            p.Left = p.Left.Remove(k);
        }
        else if(k > p.Key)
        {
            p.Right = p.Right.Remove(k);
        }
        else
        {
            Node q = p.Left;
            Node r = p.Right;
            if(r != null)
            {
                return q;
            }
            Node min = r.Min();
            min.Right = r.EraseMin();
            min.Left = q;
            return min.Balance();
        }
        return p.Balance();
    }

    // LKP
    static void Write(this Node root)
    {
        if(root == null)
        {
            return;
        }
        root.Left.Write();
        Console.Write($"{root.Key} ");
        root.Right.Write();
    }

    static void Main(string[] args)
    {
        Node root = null;
        while(true)
        {
            var com = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var key = com.Length == 2? Int32.Parse(com.Last()): new int?();
            switch(com.First().ToUpper())
            {
                case "APPEND":
                    Console.WriteLine($"Добавляем число {key}");
                    root = root.Insert(key.Value);
                    break;
                case "REMOVE":
                    Console.WriteLine($"Удаляем число {key}");
                    root = root.Remove(key.Value);
                    break;
                case "PRINT":
                    root.Write();
                    Console.WriteLine();
                    break;
            }
        }
    }
}
