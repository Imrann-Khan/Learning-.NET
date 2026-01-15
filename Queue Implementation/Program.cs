// Generic Class
Queue<int> nums = new();

nums.Enqueue(10);
nums.Enqueue(20);
nums.Enqueue(30);
Console.WriteLine($"{nums.Count}");
Console.WriteLine($"{nums.Peek()}");
int x = nums.Dequeue();
Console.WriteLine($"{x}");
Console.WriteLine($"{nums.Count}");
Console.WriteLine($"{nums.Peek()}");
nums.Dequeue();
nums.Dequeue();
nums.Dequeue();


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

class Queue<T>
{
    public int Count {get; set;}
    public Node<T> Front;
    public Node<T> Rear;

    public Queue()
    {
        Count = 0;
        Front = null;
        Rear = null;
    }

    public void Enqueue(T Value)
    {
        Node<T> NewNode = new(Value);
        if (Rear == null)
        {
            Front = NewNode;
            Rear = NewNode;
        }
        else
        {
            Rear.Next = NewNode;
            Rear = NewNode;
        }
        Count++;
    }

    public T Dequeue()
    {
        if(Count==0)
        {
            Console.Write("Queue Empty!");
            return default(T);
        }

        T ret = Front.Value;
        Front = Front.Next;
        Count--;
        if (Front == null)
        {
            // Queue became empty; reset rear as well
            Rear = null;
        }
        return ret;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            Console.Write("Queue Empty!");
            return default(T);
        }
        return Front.Value;
    }
}