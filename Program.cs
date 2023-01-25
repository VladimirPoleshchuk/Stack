namespace Stack
{
    class Program
    {
        static void Main()
        {
            Stack stack = new Stack(" ");
            stack.Add("!");
            stack.Add("Mир");
            stack.Add("Привет");

            Console.WriteLine(stack.Size);
            Console.WriteLine(stack.Top);
            stack.Pop();
            stack.Pop();
            Console.WriteLine(stack.Size);
            Console.WriteLine(stack.Top is null ? "null" : stack.Top);
            Console.WriteLine(stack.Size);

            Stack stack1 = Stack.Concat(stack, new Stack("Я", " ", "Здесь"));
            Console.WriteLine(stack1.Size);
            Console.WriteLine(stack1.Top);

            stack1.Merge(new Stack("Учусь вместе с вами."));
            Console.WriteLine(stack1.Size);
            Console.WriteLine(stack1.Top);

            Console.WriteLine(stack1);

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
        private StackItem stackItemHead = null;

        public int Size { get; private set; }

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
                    return stackItemHead.Item;
                }
            }
        }

        public Stack(params string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                StackItem stackItem = new();
                stackItem.PreviousItem = stackItemHead;
                stackItem.Item = lines[i];
                stackItemHead = stackItem;
                Size++;
            }
        }

        public void Add(string line)
        {
            StackItem stackItem = new();
            stackItem.PreviousItem = stackItemHead;
            stackItem.Item = line;
            stackItemHead = stackItem;
            Size++;
        }

        public string Pop()
        {
            string line = "";

            try
            {
                line = stackItemHead.Item;

                stackItemHead.Item = stackItemHead.PreviousItem is null ? null : stackItemHead.PreviousItem.Item;
                stackItemHead.PreviousItem = stackItemHead.PreviousItem is null ? null : stackItemHead.PreviousItem.PreviousItem;

                Size--;

                if (Size < 0)
                {
                    Size = 0;
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception("Стек пуст");
            }

            return line;
        }

        static public Stack Concat(params Stack[] stacks)
        {
            Stack result = new();

            foreach (Stack stack in stacks)
            {
                StackItem lineNext = stack.stackItemHead;

                while (lineNext != null)
                {
                    result.Add(lineNext.Item);

                    lineNext = lineNext.PreviousItem;
                }
            }

            return result;
        }

        public override string ToString()
        {
            string line = "";

            StackItem lineNext = stackItemHead;

            while (lineNext != null)
            {
                line += lineNext.Item;

                lineNext = lineNext.PreviousItem;
            }

            return line;
        }

        private class StackItem
        {
            public string Item { get; set; }
            public StackItem PreviousItem { get; set; }
        }
    }
}