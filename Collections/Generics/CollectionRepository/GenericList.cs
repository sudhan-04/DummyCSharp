using ConsoleTables;
using Pastel;

/// <summary>
/// Class which handles a generic list
/// </summary>
/// <typeparam name="T">The type of the element in the list</typeparam>
public class GenericList<T>
{
    List<T> inputList;

    /// <summary>
    /// Constructor block to assign the list
    /// </summary>
    /// <param name="inputList">The list which is injected through the constructor</param>
    public GenericList(List<T> inputList)
    { this.inputList = inputList; }

    /// <summary>
    /// Method to print about the successful creation of a list
    /// </summary>
    public void CreateList()
    {
        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe List of {typeof(T).ToString().Replace("System.", "")} is successfully created !!".Pastel(ConsoleColor.Cyan));
    }

    /// <summary>
    /// Method to check if an element is present in the list
    /// </summary>
    public void CheckItem(T input)
    {
        Console.WriteLine($"\n--------CHECKING--------".Pastel(ConsoleColor.Magenta));

        if (inputList.Contains(input))
        {
            Console.WriteLine($"\n{input} is present in the list !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\n{input} is not present in the list !!".Pastel(ConsoleColor.Red));
        }
    }

    /// <summary>
    /// Method which returns the List as a Console Table
    /// </summary>
    /// <returns>The Console Table which is built from the list</returns>
    public ConsoleTable ReturnListAsTable()
    {
        Console.WriteLine($"\nAll the items in the list are : ".Pastel(ConsoleColor.Yellow));

        ConsoleTable listTable = new ConsoleTable("S_No", "Item");

        for (int count = 1; count <= inputList.Count(); count++)
            listTable.AddRow(count, inputList[count - 1]);

        return listTable;
    }

    /// <summary>
    /// Method to remove an element from the list
    /// </summary>
    public void RemoveItem(T input)
    {
        Console.WriteLine($"\n--------REMOVING--------".Pastel(ConsoleColor.Magenta));

        if (inputList.Remove(input))
        {
            Console.WriteLine($"\n'{input}' is successfully deleted from the list !!".Pastel(ConsoleColor.Cyan));
        }
        else
        {
            Console.WriteLine($"\n'{input}' is not present in the list !!".Pastel(ConsoleColor.Red));
        }
    }

    /// <summary>
    /// Method to add an element to the list
    /// </summary>
    public void AddItem(T input)
    {
        Console.WriteLine($"\n--------ADDING--------".Pastel(ConsoleColor.Magenta));

        inputList.Add(input);

        Console.WriteLine($"\n'{input}' is successfully added to the list !!".Pastel(ConsoleColor.Cyan));
    }
}
