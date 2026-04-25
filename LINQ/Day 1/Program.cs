using System.Linq;
class Program
{
    public static void Main(string[] args)
    {
        // Data Source
        List<int> list = new List<int>(){
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

        // 1. Query (Query Syntax)
        var QuerySyntax = from i in list
                            where i >= 5
                            select i;
        
        // // 2. Query (Method Syntax)
        // var QuerySyntax = list.Where(i => i>=5).ToList();

        // Execution
        foreach(var i in QuerySyntax)
        {
            Console.Write($"{i} ");
        }
    }
}
