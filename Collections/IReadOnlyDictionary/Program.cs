using ConsoleTables;

public class Program
{
    /// <summary>
    /// Generates an IReadOnlyDictionary with few key value pairs
    /// </summary>
    /// <returns>The Generated IReadOnlyDictionary</returns>
    static IReadOnlyDictionary<string, int> GenerateDictionary()
    {
        var immutableDictionary = new Dictionary<string, int>();

        immutableDictionary.Add("Banana", 1);
        immutableDictionary.Add("Carrot", 2);
        immutableDictionary.Add("Watermelon", 3);
        immutableDictionary.Add("Guava", 4);
        immutableDictionary.Add("Papaya", 5);

        return immutableDictionary;
    }

    /// <summary>
    /// Prints an IReadOnlyDictionary as a ConsoleTable
    /// </summary>
    /// <param name="dictionary">The IReadOnlyDictionary which is to be printed</param>
    static void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
    {
        ConsoleTable keyValuePairs = new ConsoleTable("Key","Value");

        foreach (var pair in dictionary)
        {
            keyValuePairs.AddRow(pair.Key, pair.Value);
        }

        keyValuePairs.Write();
    }

    /// <summary>
    /// The Main method
    /// </summary>
    static void Main()
    {
        var testDictionary = GenerateDictionary();

        PrintDictionary(testDictionary);

        //testDictionary["Apple"] = 10;
    }
}