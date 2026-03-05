
Whiteboard board1 = Whiteboard.GetInstance();
board1.Write("I want to learn C#.");
board1.Print();

Whiteboard board2 = Whiteboard.GetInstance();
board2.Write("This is the first step of Learning.");
board2.Print();

class Whiteboard
{
    private static Whiteboard Instance = null;
    public string Content;

    private Whiteboard() {}

    public static Whiteboard GetInstance()
    {
        if(Instance == null) 
            return Instance = new Whiteboard();
        return Instance;
    }

    public void Write(string Message)
    {
        this.Content=this.Content+"\n"+Message;
    }
    public void Print()
    {
        Console.WriteLine($"Whiteboard Content: {this.Content}");
    }
}