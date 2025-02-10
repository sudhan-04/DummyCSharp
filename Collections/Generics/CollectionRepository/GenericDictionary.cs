using ConsoleTables;
using Pastel;

namespace Generics.CollectionRepository
{
    /// <summary>
    /// Class which handles a generic dictionary
    /// </summary>
    /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
    /// <typeparam name="TValue">The type of the value in the dictionary</typeparam>
    public class GenericDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> genericDictionary;

        /// <summary>
        /// Constructor block to assign the dictionary
        /// </summary>
        /// <param name="genericDictionary">The dictionary which is injected through the constructor</param>
        public GenericDictionary(Dictionary<TKey, TValue> genericDictionary)
        { this.genericDictionary = genericDictionary; }

        /// <summary>
        /// Method to print about the successful creation of a dictionary
        /// </summary>
        public void CreateDictionary()
        {
            Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
            Console.WriteLine($"\nThe Dictionary of ({typeof(TKey).ToString().Replace("System.", "")}, {typeof(TValue).ToString().Replace("System.", "")}) is successfully created !!".Pastel(ConsoleColor.Cyan));

        }

        /// <summary>
        /// Method which returns the Dictionary as a Console Table
        /// </summary>
        /// <returns>The Console Table which is built from the dictionary</returns>
        public ConsoleTable ReturnDictionaryAsTable()
        {
            Console.WriteLine($"\nAll the items in the dictionary are : ".Pastel(ConsoleColor.Yellow));

            ConsoleTable dictionaryTable = new ConsoleTable("S_No", "Key", "Value");

            for (int count = 1; count <= genericDictionary.Count(); count++)
                dictionaryTable.AddRow(count, genericDictionary.ElementAt(count - 1).Key, genericDictionary.ElementAt(count - 1).Value);

            return dictionaryTable;
        }

        /// <summary>
        /// Method to remove a key-value pair from the dictionary
        /// </summary>
        /// <param name="deleteKey">The key which is to be removed from the dictionary</param>
        public void RemoveItemFromDictionary(TKey deleteKey)
        {
            Console.WriteLine($"\n--------REMOVING--------".Pastel(ConsoleColor.Magenta));

            if (genericDictionary.Remove(deleteKey))
            {
                Console.WriteLine($"\n'{deleteKey}' is successfully deleted from the dictionary !!".Pastel(ConsoleColor.Cyan));
            }
            else
            {
                Console.WriteLine($"\n'{deleteKey}' is not present in the dictionary !!".Pastel(ConsoleColor.Red));
            }
        }

        /// <summary>
        /// Method to add a key-value pair to a dictionary
        /// </summary>
        /// <param name="addKey">The key which is to be added</param>
        /// <param name="addValue">The value of the key which is to be added</param>
        public void AddItemToDictionary(TKey addKey, TValue addValue)
        {
            Console.WriteLine($"\n--------ADDING--------\n".Pastel(ConsoleColor.Magenta));

            genericDictionary.Add(addKey, addValue);

            Console.WriteLine($"\n'{addKey},{addValue}' is successfully added to the dictionary !!".Pastel(ConsoleColor.Cyan));
        }
    }
}
