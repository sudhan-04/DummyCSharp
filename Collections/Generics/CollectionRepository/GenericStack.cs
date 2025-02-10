using ConsoleTables;
using Pastel;

/// <summary>
/// Class which handles a generic stack
/// </summary>
/// <typeparam name="T">The type of the element in the stack</typeparam>
public class GenericStack<T>
{
    Stack<T> genericStack;

    /// <summary>
    /// Constructor block to assign the stack
    /// </summary>
    /// <param name="inputQueue">The stack which is injected through the constructor</param>
    public GenericStack(Stack<T> genericStack)
    { this.genericStack = genericStack ; }

    /// <summary>
    /// Method to print about the successful creation of a stack
    /// </summary>
    public void CreateStack()
    {
        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe Stack of {typeof(T).ToString().Replace("System.", "")} is successfully created !!".Pastel(ConsoleColor.Cyan));
    }

    /// <summary>
    /// Method which returns the Queue as a Console Table
    /// </summary>
    /// <param name="inputStack">The stack whose elements is allocated to the Console Table</param>
    /// <returns>The Console Table which is built from the queue</returns>
    public ConsoleTable ReturnStackAsTable(Stack<T> inputStack)
    {
        Console.WriteLine($"\nAll the items in the stack are : ".Pastel(ConsoleColor.Yellow));

        ConsoleTable stackTable = new ConsoleTable("S_No", "Item");
        for (int count = 1; count <= inputStack.Count(); count++)
            stackTable.AddRow(count, inputStack.ElementAt(count - 1));

        return stackTable;
    }

    /// <summary>
    /// Method to remove an element from the stack
    /// </summary>
    public void PopItem()
    {
        Console.WriteLine($"\n--------POPPING--------".Pastel(ConsoleColor.Magenta));

        T deletedItem = genericStack.Pop();

        if (deletedItem != null)
        {
            Console.WriteLine($"\n'{deletedItem}' is successfully popped from the Stack !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\nThe stack is empty !!".Pastel(ConsoleColor.Red));
        }
        
    }
    
    /// <summary>
    /// Method which pops all the elements of a stack and pushes it to another stack
    /// </summary>
    public void ReverseContent()
    {
        Stack<T> reversedStack = new Stack<T> ();

        while (genericStack.Count > 0)
        {
            reversedStack.Push (genericStack.Pop());
        }

        Console.WriteLine($"\nReversed Stack : ".Pastel(ConsoleColor.Yellow));

        ReturnStackAsTable(reversedStack).Write();
    }

    /// <summary>
    /// Method to add an element to the stack
    /// </summary>
    public void PushItem(T input)
    {
        Console.WriteLine($"\n--------PUSHING--------\n".Pastel(ConsoleColor.Magenta));

        genericStack.Push(input);

        Console.WriteLine($"\n'{input}' is successfully added to the stack !!".Pastel(ConsoleColor.Cyan));
        
    }
}
