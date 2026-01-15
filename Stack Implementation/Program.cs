// Generic Class

Stack<string> nums = new();

nums.Push("apple");
nums.Push("mango");
nums.Push("Jackfruit");
Console.WriteLine($"{nums.Size}");
Console.WriteLine($"{nums.Peek()}");
string x = nums.Pop();
Console.WriteLine($"{x}");
Console.WriteLine($"{nums.Size}");
Console.WriteLine($"{nums.Peek()}");
nums.Pop();
nums.Pop();
nums.Pop();



class Node<T>
{
    public T Value;
    public Node<T> Next;

    public Node(T value)
    {
        this.Value = value;
        this.Next = null;
    }
}

class Stack<T>
{
    public Node<T> top;
    public int Size {get; set;}

    public Stack()
    {
        top=null;
        Size = 0;
    }

    public T Pop()
    {
        if (top == null)
        {
            throw new IOException("Stack must not be empty!");
        }

        Node<T> temp = top;
        top=top.Next;
        Size--;
        return temp.Value;
    }

    public T Peek()
    {
        if (top == null)
        {
            Console.WriteLine("Stack Empty!");
            return default(T);
        }

        return top.Value;
    }

    public void Push(T value)
    {
        Node<T> NewNode  = new(value);
        NewNode.Next=top;
        top = NewNode;
        Size++;
    }
}
