// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {

    }
}

public static class StackExtensions
{
    public static void Merge(this Stack stack1, Stack stack2)
    {
        for (int i = 0; i < stack2.Size; i++)
        {
            stack1.Add(stack2.Top);
        }
    }
}

public class Stack
{
    private List<string> list = new List<string>();

    public int Size
    {
        get { return list.Count; }
    }

    public string Top
    {
        get
        {
            if (Size == 0)
            {
                return null;
            }
            else
            {
                return list[list.Count - 1];
            }
        }
    }

    public Stack(params string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            list.Add(lines[i]);
        }
    }

    public void Add(string line)
    {
        list.Add(line);
    }

    public string Pop()
    {
        string line = "";
        try
        {
            line = list.Last();
            list.RemoveAt(list.Count - 1);
        }
        catch (Exception)
        {
            throw new Exception("Стек пуст");
        }

        return line;
    }

    static public Stack Concat(params Stack[] stack)
    {
        Stack result = new();

        foreach (Stack line in stack)
        {
            for (int i = line.Size - 1; i >= 0; i--)
            {
                result.Add(line.list[i]);
            }
        }

        return result;
    }
}
