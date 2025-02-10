using Pastel;

public class CharacterStack
{
    Stack<char> characterStack;

    /// <summary>
    /// Constructor block to assign the stack
    /// </summary>
    /// <param name="characterStack">The stack which is injected through the constructor</param>
    public CharacterStack(Stack<char> characterStack)
    { this.characterStack = characterStack ; }

    /// <summary>
    /// Performs the required stack operations
    /// </summary>
    public void DoStackOperations()
    {

        Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
        Console.WriteLine($"\nThe Stack of characters is successfully created !!".Pastel(ConsoleColor.Cyan));

        Console.Write($"Provide the input string : ".Pastel(ConsoleColor.Yellow));
        string inputString = GetValidString(Console.ReadLine());

        PushToStack(inputString);

        string reversedInput = PopFromStack();

        Console.WriteLine($"Original Input String : ".Pastel(ConsoleColor.Yellow)+inputString);
        Console.WriteLine($"Reversed String after popping : ".Pastel(ConsoleColor.Yellow)+reversedInput);

    }

    /// <summary>
    /// Method to remove an element from the stack
    /// </summary>
    private string PopFromStack()
    {
        Console.WriteLine($"\n--------REMOVING CHARACTERS--------".Pastel(ConsoleColor.Magenta));
        string outputString = "";
        int stringLength = characterStack.Count();
        for (int loopCount  = 0; loopCount < stringLength; loopCount++)
            outputString += characterStack.Pop();

        Console.WriteLine($"\nAll the Characters are popped from the stack successfully.\n".Pastel(ConsoleColor.Cyan));
        return outputString;
    }

    /// <summary>
    /// Method to add an element to the stack
    /// </summary>
    private void PushToStack(string inputString)
    {
        Console.WriteLine($"\n--------ADDING CHARACTERS--------".Pastel(ConsoleColor.Magenta));
        foreach(char character in inputString)
        {
            characterStack.Push(character);
        }

        Console.WriteLine($"\nAll the Characters are pushed into the stack successfully.".Pastel(ConsoleColor.Cyan));
    }

    /// <summary>
    /// Method to get a valid string
    /// </summary>
    /// <param name="inputString">String which is checked if it is valid</param>
    /// <returns>A valid string</returns>
    private string GetValidString(string inputString)
    {
        while (inputString == "" || inputString == null)
        {
            Console.WriteLine($"The given string is either null or empty !!!".Pastel(ConsoleColor.Red));
            Console.Write($"Provide a valid string :".Pastel(ConsoleColor.Yellow));
            inputString = Console.ReadLine();
        }

        return inputString;
    }
}
