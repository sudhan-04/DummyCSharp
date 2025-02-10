using ConsoleTables;
using Pastel;

/// <summary>
/// Class which handles a generic queue
/// </summary>
/// <typeparam name="T">The type of the element in the queue</typeparam>
public class GenericQueue<T>
{
    Queue<T> inputQueue;

    /// <summary>
    /// Constructor block to assign the queue
    /// </summary>
    /// <param name="inputQueue">The queue which is injected through the constructor</param>
    public GenericQueue(Queue<T> inputQueue)
    { this.inputQueue = inputQueue; }

    /// <summary>
    /// Method to print about the successful creation of a queue
    /// </summary>
    public void CreateQueue()
    {
        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe Queue of {typeof(T).ToString().Replace("System.", "")} is successfully created !!".Pastel(ConsoleColor.Cyan));
    }

    /// <summary>
    /// Method which returns the Queue as a Console Table
    /// </summary>
    /// <returns>The Console Table which is built from the queue</returns>
    public ConsoleTable ReturnQueueAsTable()
    {
        Console.WriteLine($"\nAll the items in the queue are : ".Pastel(ConsoleColor.Yellow));
        ConsoleTable queueTable = new ConsoleTable("S_No", "Item");
        for (int count = 1; count <= inputQueue.Count(); count++)
            queueTable.AddRow(count, inputQueue.ElementAt(count-1));
        return queueTable;
    }

    /// <summary>
    /// Method to remove an element from the queue
    /// </summary>
    public void DequeueItem()
    {
        Console.WriteLine($"\n--------DEQUEUEING--------".Pastel(ConsoleColor.Magenta));

        T deletedItem = inputQueue.Dequeue();

        if ( deletedItem != null)
        {
            Console.WriteLine($"\n'{deletedItem}' is successfully deleted from the queue !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\nThe queue is empty !!".Pastel(ConsoleColor.Red));
        }
    }

    /// <summary>
    /// Method to add an element to the queue
    /// </summary>
    public void EnqueueItem(T input)
    {
        Console.WriteLine($"\n--------ENQUEUEING--------\n".Pastel(ConsoleColor.Magenta));

        inputQueue.Enqueue(input);

        Console.WriteLine($"\n'{input}' is successfully added to the queue !!".Pastel(ConsoleColor.Cyan));
    }
}
