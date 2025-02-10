using Pastel;

public class Program
{
    /// <summary>
    /// Method to sum integers in IEnumerable<int> collection
    /// </summary>
    /// <param name="integerCollection">IEnumerable<int> collection whose elements sum is to be collected</param>
    /// <returns>The sum of the integers in the IEnumerable<int> collection</returns>
    public static int SumOfElements(IEnumerable<int> integerCollection)
    {
        int sum = 0;
        foreach (int integer in integerCollection)
        {
            sum += integer;
        }

        return sum;
    }

    /// <summary>
    /// The Main Method
    /// </summary>
    static void Main()
    {
        List<int> integerList = new List<int> { 1, 2, 3, 4, 5 };
        Queue<int> integerQueue = new Queue<int> (new List<int> { 1, 2, 3, 4, 5 });
        Stack<int> integerStack = new Stack<int> (new List<int> { 1, 2, 3, 4, 5 });
        int[] integerArray = [1, 2, 3, 4, 5];

        Console.WriteLine($"The sum of integer elements in the List : ".Pastel(ConsoleColor.Yellow)+$"{SumOfElements(integerList)}".Pastel(ConsoleColor.Cyan));
        Console.WriteLine($"\nThe sum of integer elements in the Queue : ".Pastel(ConsoleColor.Yellow)+ $"{SumOfElements(integerQueue)}".Pastel(ConsoleColor.Cyan));
        Console.WriteLine($"\nThe sum of integer elements in the Stack : ".Pastel(ConsoleColor.Yellow)+$"{SumOfElements(integerStack)}".Pastel(ConsoleColor.Cyan));
        Console.WriteLine($"\nThe sum of integer elements in the Array : ".Pastel(ConsoleColor.Yellow)+$"{SumOfElements(integerArray)}".Pastel(ConsoleColor.Cyan));
    }
}